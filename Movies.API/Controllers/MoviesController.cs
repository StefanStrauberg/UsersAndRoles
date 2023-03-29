using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Interfaces;
using Movies.API.Models;
using Microsoft.AspNetCore.Http;

namespace Movies.API.Controllers
{
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

        [HttpGet]
        [ProducesResponseType(typeof(List<MovieDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var movies = await _repository.GetAsync();
            var dtos = _mapper.Map<List<MovieDto>>(movies);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (movie is null)
                return BadRequest("Movie with id not found");
            var dto = _mapper.Map<MovieDto>(movie);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Post(CreateMovieDto createMovieDto)
        {
            var movie = _mapper.Map<Movie>(createMovieDto);
            await _repository.CreateAsync(movie);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = await _repository.GetByIdAsync(id);
            if  (movie is null)
                return BadRequest("Movie with id not found");
            _mapper.Map(updateMovieDto, movie, typeof(UpdateMovieDto), typeof(Movie));
            await _repository.UpdateAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var movieToDelete = await _repository.GetByIdAsync(id);
            if (movieToDelete is null)
                return BadRequest("Movie with id not found");
            await _repository.DeleteAsync(movieToDelete);
            return NoContent();
        }
    }
}