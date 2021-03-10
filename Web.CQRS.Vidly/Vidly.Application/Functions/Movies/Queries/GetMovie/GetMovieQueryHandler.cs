using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Vidly.Application.Contracts.Presistence;
using Vidly.Application.Functions.Movies.Dtos;
using Vidly.Domain.Entities;

namespace Vidly.Application.Functions.Movies.Queries.GetMovie
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public GetMovieQueryHandler(IMapper mapper, IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<MovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);
            return _mapper.Map<MovieDto>(movie);
        }
    }
}
