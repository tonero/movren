using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext _dbContext;

        public RentalsController()
        {
            _dbContext = new ApplicationDbContext();
        }


        //Post /api/rentals/
        [HttpPost]
        public IHttpActionResult CreateRentals(RentalDto rentalsDto)
        {
            var movies = _dbContext.Movies.Where(m => rentalsDto.MovieIds.Contains(m.Id)).ToList();
            //if there are no movies in the DTO
            if (rentalsDto.MovieIds.Count() == 0)
                return BadRequest("Movies are not available");

            //if the number of movies in the dto does not match the number of movies in the movies variable
            if (movies.Count != rentalsDto.MovieIds.Count)
                return BadRequest("All Movies were not loaded please refresh and try again");

            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == rentalsDto.CustomerId);
            //if customer in DTO is not in DB
            if (customer == null)
                return BadRequest("Customer is Not Valid");

            foreach(var movie in movies)
            {

                if (movie.NumberAvailable == 0)
                    return BadRequest("Requested Movie "+movie.Name+" is not available please search for another");

                var rentals = new Rental()
                {

                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now

                };
                _dbContext.Rental.Add(rentals);
                movie.NumberAvailable--;
                
               

               

            }
            _dbContext.SaveChanges(); 
           
            return Ok();
        }
    }
}
