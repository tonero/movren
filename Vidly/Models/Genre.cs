using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public Byte Id { get; set; }
        public String Name { get; set; }

        public static implicit operator Genre(List<Genre> v)
        {
            throw new NotImplementedException();
        }
    }
}