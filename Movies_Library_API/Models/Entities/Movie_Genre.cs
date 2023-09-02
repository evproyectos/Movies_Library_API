using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movies_Library_API.Models.Entities
{
    public class Movie_Genre
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }

        [ForeignKey("GenreId")]
        public int GenreId { get; set; }
    }
}