using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        public String Name { get; set; }
        
        public Byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
    
        public short NumberInStock { get; set; }

        public GenreDto Genre { get; set; }
    }
}