using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _dbContext;

        public MovieController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        //GET: Movie/Index
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("MovieList-rw");
            }
            return View("MovieList-r");
        }

        //GET: Movie/Detail
        public ActionResult Details(int id)
        {
          
            return GetMovieDetails(id,"Details");
        }

        //editting a selected movie
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            return GetMovieDetails(id,"MovieForm") ;
        }

        //Display the movie form
        [Authorize (Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            var Genre = _dbContext.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = Genre
            }; 

            return View(viewModel);
        }

        //When a user taps on the save button of the movie form
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles = RoleName.CanManageMovies)]
        public ActionResult Save(MovieDto Movie)
        {

            if (!ModelState.IsValid)
            {
                var Genre = _dbContext.Genre.ToList();
                var viewModel = new MovieFormViewModel
                {
                    Movie = GetMovieMapping(Movie),
                    Genres = Genre
                };
                return View("MovieForm", viewModel);
            }

            if(Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                var newMovie = GetMovieMapping(Movie);
                _dbContext.Movies.Add(newMovie);  
                _dbContext.SaveChanges();               
                Movie.Id = newMovie.Id;

            }
            else
            {
                Movie.DateAdded = DateTime.Now;
                var movieInDb = _dbContext.Movies.Single(m => m.Id == Movie.Id);
                Mapper.Map<MovieDto, Movie>(Movie, movieInDb);
                _dbContext.SaveChanges();


            }
            return RedirectToAction("Index", "Movie");
        }
        
        public Movie GetMovieMapping (MovieDto Movie)
        {
            return Mapper.Map<MovieDto, Movie>(Movie);
        }

        public ActionResult GetMovieDetails(int id, String view)
        {
            var movieDetails = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movieDetails == null)
                return HttpNotFound();


            var viewModel = new MovieFormViewModel
            {
                Movie = movieDetails,
                Genres = _dbContext.Genre.ToList()
            };
            return View(view, viewModel);
        }

    }
}