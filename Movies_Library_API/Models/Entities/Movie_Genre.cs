using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movies_Library_API.Models.Entities
{
    [Table("Movie_Genres")]
    public class Movie_Genre
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }


        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set;}

    }
}