using System;

namespace Vidly.Application.Functions.Movies
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public short Count { get; set; }
        public int GenreId { get; set; }
    }
}
