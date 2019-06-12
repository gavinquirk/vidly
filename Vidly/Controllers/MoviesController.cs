using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // Index View Result
        public ViewResult Index()
        {
            // Create movies list with GetMovies
            var movies = GetMovies();

            // Return view with movies list data
            return View(movies);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            // New movie
            var movie = new Movie() { Name = "Shrek" };

            // New list of customers
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            // View Model
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            // Return
            return View(viewModel);
        }

        // Get List of Movies
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Star Wars: A New Hope" },
                new Movie {Id = 2, Name = "The Matrix" }
            };
        }


    }
}