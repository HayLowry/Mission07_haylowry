using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission07_haylowry.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryID = 1,
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryID = 2,
                    Title = "Pride & Prejudice",
                    Year = 2005,
                    Director = "Joe Wright",
                    Rating = "PG"
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryID = 3,
                    Title = "Bee Movie",
                    Year = 2007,
                    Director = "Simon J. Smith",
                    Rating = "PG"
                }
            );
        }
    }
}
