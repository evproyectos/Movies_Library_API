using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Library_API.Models.Data;
using Movies_Library_API.Models.Entities;

namespace Movies_Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesBDContext _context;
        public MoviesController(MoviesBDContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("Movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            List<Movie> movies = await _context.Movies.ToListAsync();
            
            return movies;
        }

        [HttpGet]
        [Route("Movies_genre")]
        public async Task<ActionResult<IEnumerable<Movie_Genre>>> GetMovieGenre()
        {
            List<Movie_Genre> movie_genres = await _context.Movie_Genres
                .Include(mg => mg.Movie).Include(mg => mg.Genre).ToListAsync();

            return movie_genres;
        }

        [HttpPost]
        [Route("Movies_add_total")]
        public async Task<IActionResult> CreateMovieWithGenres([FromBody] Movie movie, [FromQuery] int[] GenreId)
        {
            if (movie == null || GenreId == null)
            {
                return BadRequest();
            }

            foreach (var genreID in GenreId)
            {
                Movie_Genre movie_Genre = new()
                {
                    Movie = movie,
                    MovieId = movie.Id,
                    GenreId = genreID
                };    
                
                _context.Movie_Genres?.Add(movie_Genre);       
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        [HttpPost]
        [Route("Movies_add_genres")]
        public async Task<IActionResult> CreateMovie(int movieId,[FromBody] List<int> genreIDs)
        {
            if(genreIDs == null || genreIDs.Count == null)
                return BadRequest("No genre IDs provided");
            
            var movie = _context.Movies.FindAsync(movieId);

            if(movie == null)
                return NotFound("Movie not found");

            foreach (var genreID in genreIDs)
            {
                Movie_Genre movie_Genre = new()
                {
                    MovieId = movieId,
                    GenreId = genreID
                };

                _context.Movie_Genres.Add(movie_Genre);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        
 
    }
}