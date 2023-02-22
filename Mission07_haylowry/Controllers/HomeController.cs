using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission07_haylowry.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission07_haylowry.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext moviesContext { get; set; }

        public HomeController(MoviesContext moviesContextParam)
        {
            this.moviesContext = moviesContextParam;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(Movie movie)
        {
            moviesContext.Add(movie);
            moviesContext.SaveChanges();
            return View("MovieReceived", movie);
        }
        public IActionResult MovieList()
        {
            var movies = moviesContext.Movies
                //.Where(x => x.rating == "PG")
                .OrderBy(y => y.Title)
                .ToList();
            return View(movies);
        }

    }
}
