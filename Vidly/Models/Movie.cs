using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {

        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public Byte GenreId { get; set; }

        [Required]
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

      
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="The field Number In Stock must have a value greater than 0")]
        [Display(Name = "Number In Stock")]
        public short NumberInStock { get; set; }

        public short NumberAvailable { get; set; }

    }
}