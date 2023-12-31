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
        [Route("Movies-genre")]
        public async Task<ActionResult<IEnumerable<Movie_Genre>>> GetMovieGenre()
        {
            List<Movie_Genre> movie_genres = await _context.Movie_Genres
                .Include(mg => mg.Movie)
                .Include(mg => mg.Genre)
                .ToListAsync();

            return movie_genres;
        }
    }
}