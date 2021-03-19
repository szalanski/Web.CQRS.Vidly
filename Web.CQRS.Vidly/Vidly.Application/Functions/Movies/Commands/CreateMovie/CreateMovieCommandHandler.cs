using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Vidly.Application.Contracts.Presistence;
using Vidly.Application.Functions.Movies.Commands.CreateMovie;
using Vidly.Domain.Entities;

namespace Vidly.Application.Functions.Movies.Commands
{
	public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
	{
		#region Fields

		private readonly IMovieRepository _movieRepository;
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;

		#endregion Fields

		#region Constructors

		public CreateMovieCommandHandler(IMapper mapper, IMovieRepository movieRepository, IGenreRepository genreRepository)
		{
			_movieRepository = movieRepository;
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		#endregion Constructors

		#region Public Methods

		public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateMovieCommandValidator();
			var validationResult = await validator.ValidateAsync(request);
			if(!validationResult.IsValid)
				return new CreateMovieCommandResponse(validationResult);

			var movie = _mapper.Map<Movie>(request);
			movie.Genre = await _genreRepository.GetByIdAsync(movie.GenreId);

			movie = await _movieRepository.AddsAsync(movie);
			return new CreateMovieCommandResponse(movie.Id);
		}

		#endregion Public Methods
	}
}