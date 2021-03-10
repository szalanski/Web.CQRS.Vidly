using MediatR;
using Vidly.Application.Functions.Movies.Dtos;

namespace Vidly.Application.Functions.Movies.Queries.GetMovie
{
    public class GetMovieQuery : IRequest<MovieDto>
    {
        public int Id { get; set; }
    }
}
