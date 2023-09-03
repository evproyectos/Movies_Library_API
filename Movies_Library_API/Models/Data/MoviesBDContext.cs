using Microsoft.EntityFrameworkCore;
using Movies_Library_API.Models.Entities;

namespace Movies_Library_API.Models.Data
{
    public class MoviesBDContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie_Genre> Movie_Genres { get; set; }

        public MoviesBDContext(IConfiguration configuration) => _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("MoviesBD"));
        }
    }
}