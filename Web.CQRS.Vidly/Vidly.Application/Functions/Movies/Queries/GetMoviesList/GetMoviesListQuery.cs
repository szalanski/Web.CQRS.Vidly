using System.Collections.Generic;
using MediatR;

namespace Vidly.Application.Functions.Movies.Queries.GetMoviesList
{
    public class GetMoviesListQuery : IRequest<List<MovieDto>>
    {
    }
}
