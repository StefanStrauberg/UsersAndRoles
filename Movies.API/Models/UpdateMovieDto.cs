using System;

namespace Movies.API.Models
{
    public class UpdateMovieDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Owner { get; set; }
    }
}