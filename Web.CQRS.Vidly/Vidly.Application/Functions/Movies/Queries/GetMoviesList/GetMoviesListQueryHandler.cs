using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Vidly.Application.Contracts.Presistence;
using Vidly.Application.Functions.Movies.Dtos;
using Vidly.Domain.Entities;

namespace Vidly.Application.Functions.Movies.Queries.GetMoviesList

{
    public class GetMoviesListQueryHandler : IRequestHandler<GetMoviesListQuery, List<MovieDto>>
    {
        private readonly IAsyncRepository<Movie> _moviesRepository;
        private readonly IMapper _mapper;

        public GetMoviesListQueryHandler(IMapper mapper, IAsyncRepository<Movie> moviesRepository)
        {
            _mapper = mapper;
            _moviesRepository = moviesRepository;
        }

        public async Task<List<MovieDto>> Handle(GetMoviesListQuery request, CancellationToken cancellationToken)
        {
            var movies = await _moviesRepository.GetAllAsync();

            return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
