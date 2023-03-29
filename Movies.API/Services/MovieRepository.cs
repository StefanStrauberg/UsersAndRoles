using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.API.Context;
using Movies.API.Interfaces;
using Movies.API.Models;

namespace Movies.API.Services
{
    public class MovieRepository : IMovieRepository
    {
        readonly DataContext _context;

        public MovieRepository(DataContext context)
            => _context = context;

        public async Task<Movie> CreateAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAsync()
            => await _context.Movies
                             .AsNoTracking()
                             .ToListAsync();

        public async Task<Movie> GetByIdAsync(int id)
            => await _context.Movies
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
    }
}