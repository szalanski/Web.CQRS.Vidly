using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Vidly.Application.Functions.Movies.Commands.CreateMovie;

namespace Vidly.Application.Functions.Movies.Commands
{
    public class CreateMovieCommand : IRequest<CreateMovieCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public short Count { get; set; }
        public int GenreId { get; set; }
    }
}
