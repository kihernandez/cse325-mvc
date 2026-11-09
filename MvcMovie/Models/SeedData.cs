using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },

                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 8.99M
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "G",
                    Price = 3.99M
                },

                // Your three favorite movies

                new Movie
                {
                    Title = "In Time",
                    ReleaseDate = DateTime.Parse("2011-10-28"),
                    Genre = "Sci-Fi",
                    Rating = "PG-13",
                    Price = 7.99M
                },

                new Movie
                {
                    Title = "The Avengers",
                    ReleaseDate = DateTime.Parse("2012-5-4"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 9.99M
                },

                new Movie
                {
                    Title = "The Patriot",
                    ReleaseDate = DateTime.Parse("2000-6-28"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 8.99M
                }
            };

            // Add movies only if they don't already exist
            foreach (var movie in movies)
            {
                var existingMovie = context.Movie.FirstOrDefault(
                    m => m.Title != null &&
                         movie.Title != null &&
                         m.Title.Trim() == movie.Title.Trim());

                if (existingMovie == null)
                {
                    context.Movie.Add(movie);
                }
                else
                {
                    existingMovie.Rating = movie.Rating;
                }
            }

            // Save changes to the database
            context.SaveChanges();
        }
    }
}