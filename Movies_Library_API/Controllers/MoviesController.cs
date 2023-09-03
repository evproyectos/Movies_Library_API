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
        [Route("Genres")]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            var tryit = await _context.Genres.ToListAsync();
            return new JsonResult(tryit);
        }
    }
}