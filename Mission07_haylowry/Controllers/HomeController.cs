using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MoviesContext MoviesContext { get; set; }

        public HomeController(MoviesContext moviesContextParam)
        {
            MoviesContext = moviesContextParam;
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
            ViewBag.Categories = MoviesContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(Movie movie)
        {
            if (ModelState.IsValid)
            {
                MoviesContext.Add(movie);
                MoviesContext.SaveChanges();
                return View("MovieReceived", movie);
            }
            else
            {
                ViewBag.Categories = MoviesContext.Categories.ToList();

                return View(movie);
            }
            
        }
        public IActionResult MovieList()
        {
            var movies = MoviesContext.Movies
                .Include(x => x.Category)
                //.Where(x => x.rating == "PG")
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = MoviesContext.Categories.ToList();

            var movie = MoviesContext.Movies.Single(x => x.MovieId == movieid);

            return View("AddMovies", movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            MoviesContext.Update(movie);
            MoviesContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = MoviesContext.Movies.Single(x => x.MovieId == movieid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            MoviesContext.Movies.Remove(movie);
            MoviesContext.SaveChanges();

            return RedirectToAction("MovieList");

        }
    }
}
