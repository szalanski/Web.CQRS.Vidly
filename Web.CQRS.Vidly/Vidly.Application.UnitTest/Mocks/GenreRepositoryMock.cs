using System.Collections.Generic;
using System.Linq;
using Moq;
using Range = Moq.Range;
using Vidly.Application.Contracts.Presistence;
using Vidly.Domain.Entities;

namespace Vidly.Application.UnitTest.Mocks
{
	public class GenreRepositoryMock
	{
		#region Fields

		public static Dictionary<GenreId, Genre> Genres = new Dictionary<GenreId, Genre>()
		{
			{GenreId.Action, new Genre() {Id = 1, Name = "Action"}},
			{GenreId.Comedy, new Genre() {Id = 2, Name = "Comedy"}},
			{GenreId.Drama, new Genre() {Id = 3, Name = "Drama"}},
			{GenreId.Fantasy, new Genre() {Id = 4, Name = "Fantasy"}},
			{GenreId.Horror, new Genre() {Id = 5, Name = "Horror"}},
			{GenreId.Romance, new Genre() {Id = 6, Name = "Romance"}},
			{GenreId.Thriller, new Genre() {Id = 7, Name = "Thriller"}},
		};

		#endregion Fields

		#region Public Static Methods

		public static Mock<IGenreRepository> GetRepository()
		{
			var genreRepo = Genres;
			var mockGenreRepository = new Mock<IGenreRepository>();

			mockGenreRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(() => genreRepo.Values.ToList());

			mockGenreRepository.Setup(repo => repo.GetByIdAsync(It.IsInRange(1, genreRepo.Count, Range.Inclusive))).ReturnsAsync((int id) => genreRepo[(GenreId)id]);

			mockGenreRepository.Setup(repo => repo.AddsAsync(It.IsAny<Genre>())).ReturnsAsync((Genre genre) =>
			{
				var id = genreRepo.Count + 1;
				genre.Id = id;
				genreRepo.Add((GenreId)id, genre);
				return genre;
			});

			mockGenreRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Genre>()))
				.Callback<Genre>(genre => genreRepo.Remove((GenreId)genre.Id));

			mockGenreRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Genre>()))
				.Callback<Genre>(genre => genreRepo[(GenreId)genre.Id] = genre);

			return mockGenreRepository;
		}

		#endregion Public Static Methods
	}
}