using System;
using System.Text;

namespace Vidly.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        public short Count { get; set; }
        public short NumberAvailable { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
