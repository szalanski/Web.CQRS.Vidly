using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Shouldly;
using Vidly.Application.Contracts.Presistence;
using Vidly.Application.Functions.Movies.Commands;
using Vidly.Application.Mapping;
using Vidly.Application.UnitTest.Mocks;
using Xunit;

namespace Vidly.Application.UnitTest.Movies.Commands
{
	public class MovieCommandsTest
	{
		#region Fields

		private readonly IMapper _mapper;
		private readonly Mock<IMovieRepository> _movieRepository;
		private readonly Mock<IGenreRepository> _genreRepository;

		#endregion Fields

		#region Constructors

		public MovieCommandsTest()
		{
			_movieRepository = MovieRepositoryMocks.GetRepository();
			_genreRepository = GenreRepositoryMock.GetRepository();

			var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
			_mapper = configurationProvider.CreateMapper();
		}

		#endregion Constructors

		#region Public Methods

		[Fact]
		public async Task Given_CreateMovieCommand_When_MovieIsValid_Then_AddMovieToRepository()
		{
			var handler = new CreateMovieCommandHandler(_mapper, _movieRepository.Object, _genreRepository.Object);

			var movieCountBeforeAdd = (await _movieRepository.Object.GetAllAsync()).Count;

			var command = new CreateMovieCommand()
			{
				Name = "A Beautiful Mind",
				Count = 7,
				GenreId = (int)GenreId.Action,
				ReleaseDate = new DateTime(2002, 3, 1),
				DateAdded = DateTime.Now,
			};


			var response = await handler.Handle(command, CancellationToken.None);

			var movieCountAfrerAdd = (await _movieRepository.Object.GetAllAsync()).Count;

			response.Success.ShouldBe(true);
			response.Id.ShouldNotBeNull();
			response.ValidationErrors.Count.ShouldBe(0);
			movieCountAfrerAdd.ShouldBe(movieCountBeforeAdd +1);
		}

		#endregion Public Methods
	}
}