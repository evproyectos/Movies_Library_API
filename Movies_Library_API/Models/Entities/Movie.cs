using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movies_Library_API.Models.Entities
{   
    [Table("Movies")]
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
    }
}