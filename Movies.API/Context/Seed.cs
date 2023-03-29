using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.API.Models;

namespace Movies.API.Context
{
    public class Seed
    {
        public static async Task SeedDataAsync(DataContext context)
        {
            if (context.Movies.Any())
                return;
            
            var data = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Counter-Strike",
                    Genre = "Action",
                    ReleaseDate = DateTime.Now
                },
                new Movie
                {
                    Id = 2,
                    Title = "Diablo",
                    Genre = "RPG",
                    ReleaseDate = DateTime.Now
                },
                new Movie
                {
                    Id = 3,
                    Title = "Need For Speed",
                    Genre = "Racing",
                    ReleaseDate = DateTime.Now
                },
                new Movie
                {
                    Id = 4,
                    Title = "Escape From Tarkov",
                    Genre = "Action",
                    ReleaseDate = DateTime.Now
                },
                new Movie
                {
                    Id = 5,
                    Title = "Warcraft",
                    Genre = "RPG",
                    ReleaseDate = DateTime.Now
                },
                new Movie
                {
                    Id = 6,
                    Title = "Asphalt",
                    Genre = "Racing",
                    ReleaseDate = DateTime.Now
                },
                new Movie
                {
                    Id = 7,
                    Title = "Painkiller",
                    Genre = "Action",
                    ReleaseDate = DateTime.Now
                },
                new Movie
                {
                    Id = 8,
                    Title = "Stalcraft",
                    Genre = "RPG",
                    ReleaseDate = DateTime.Now
                },
                new Movie
                {
                    Id = 9,
                    Title = "Forza",
                    Genre = "Racing",
                    ReleaseDate = DateTime.Now
                }
            };

            await context.Movies.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }
    }
}