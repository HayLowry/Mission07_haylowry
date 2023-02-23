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
        public DbSet<Category> Categories { get; set; }

        // seeding data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryID = 7,
                    CategoryName = "VHS"
                }
                );

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
                    CategoryID = 3,
                    Title = "Pride & Prejudice",
                    Year = 2005,
                    Director = "Joe Wright",
                    Rating = "PG"
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryID = 4,
                    Title = "Bee Movie",
                    Year = 2007,
                    Director = "Simon J. Smith",
                    Rating = "PG"
                }
            );
        }
    }
}
