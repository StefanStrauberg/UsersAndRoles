using AutoMapper;
using Movies.API.Models;

namespace Movies.API.Profiles
{
    public class MovieProfiler : Profile
    {
        public MovieProfiler()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
        }
    }
}