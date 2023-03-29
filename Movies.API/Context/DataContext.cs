using Microsoft.EntityFrameworkCore;
using Movies.API.Models;

namespace Movies.API.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}