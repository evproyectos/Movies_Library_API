using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Library_API.Models.Data;
using Movies_Library_API.Models.Entities;

namespace Movies_Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly MoviesBDContext _context;

        public GenresController(MoviesBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Genres")]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            List<Genre> genres = await _context.Genres.ToListAsync();
            return genres;
        }
    }
}