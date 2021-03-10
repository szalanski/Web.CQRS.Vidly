using System.Collections.Generic;
using MediatR;
using Vidly.Application.Functions.Movies.Dtos;

namespace Vidly.Application.Functions.Movies.Queries.GetMoviesList
{
    public class GetMoviesListQuery : IRequest<List<MovieDto>>
    {
    }
}
