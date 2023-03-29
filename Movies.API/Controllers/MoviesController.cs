using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Interfaces;
using Movies.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Movies.API.Controllers
{
    [Authorize]
    public class MoviesController : BaseApiController
    {
        readonly IMovieRepository _repository;
        readonly IMapper _mapper;
        
        public MoviesController(IMovieRepository repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        [ProducesResponseType(typeof(List<MovieDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var movies = await _repository.GetAsync();
            var moviesDto = _mapper.Map<List<MovieDto>>(movies);
            return Ok(moviesDto);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (movie is null)
                return NotFound("Movie with id not found");
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        // POST: api/Movies
        [HttpPost]
        [ProducesResponseType(typeof(MovieDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Post(CreateMovieDto createMovieDto)
        {
            var movie = _mapper.Map<Movie>(createMovieDto);
            await _repository.CreateAsync(movie);
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = await _repository.GetByIdAsync(id);
            if  (movie is null)
                return NotFound("Movie with id not found");
            _mapper.Map(updateMovieDto, movie, typeof(UpdateMovieDto), typeof(Movie));
            await _repository.UpdateAsync(movie);
            return NoContent();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var movieToDelete = await _repository.GetByIdAsync(id);
            if (movieToDelete is null)
                return NotFound("Movie with id not found");
            await _repository.DeleteAsync(movieToDelete);
            return NoContent();
        }
    }
}