using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Vidly.Application.Contracts.Presistence;
using Vidly.Domain.Entities;
using Xunit;
using Range = Moq.Range;

namespace Vidly.Application.UnitTest
{
    public class RepositoryMocks
    {
        public static Mock<IMovieRepository> GetMovieRepository()
        {
            var moviesRepo = GetMovies;

            var mockMovieRepository = new Mock<IMovieRepository>();
            mockMovieRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(moviesRepo.Values.ToList());

            mockMovieRepository.Setup(repo => repo.GetByIdAsync(It.IsInRange(1, moviesRepo.Count, Range.Inclusive))).ReturnsAsync((int id) => GetMovies[id]);

            mockMovieRepository.Setup(repo => repo.AddsAsync(It.IsAny<Movie>())).ReturnsAsync((Movie m) =>
            {
                var id = moviesRepo.Count;
                m.Id = id;
                moviesRepo.Add(GetMovies.Count, m);
                return m;
            });

            mockMovieRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Movie>()))
                .Callback<Movie>(movie => moviesRepo.Remove(movie.Id));

            mockMovieRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Movie>()))
                .Callback<Movie>(movie => moviesRepo[movie.Id] = movie);
            return mockMovieRepository;
        }

        private static Dictionary<int, Movie> GetMovies =>
        new Dictionary<int, Movie>()
            {
                {1, new Movie()
                {
                    Id = 1,
                    Name = "Gladiator",
                    Count = 3,
                    Genre = Genres[GenreId.Action],
                    GenreId = Genres[GenreId.Action].Id,
                    ReleaseDate = new DateTime(2000, 7, 14),
                    DateAdded = DateTime.Now,
                    NumberAvailable = 2,
                }},

                {2, new Movie()
                {
                    Id = 2,
                    Name = "Titanic",
                    Count = 4,
                    Genre = Genres[GenreId.Romance],
                    GenreId = Genres[GenreId.Romance].Id,
                    ReleaseDate = new DateTime(1997, 7, 14),
                    DateAdded = DateTime.Now,
                    NumberAvailable = 1,
                }},

                {3, new Movie()
                {
                    Id = 3,
                    Name = "Dark Knight Rises",
                    Count = 4,
                    Genre = Genres[GenreId.Action],
                    GenreId = Genres[GenreId.Action].Id,
                    ReleaseDate = new DateTime(2012, 7, 16),
                    DateAdded = DateTime.Now,
                    NumberAvailable = 1,
                }},

                {4, new Movie()
                {
                    Id = 4,
                    Name = "Paranormal Activity",
                    Count = 8,
                    Genre = Genres[GenreId.Horror],
                    GenreId = Genres[GenreId.Horror].Id,
                    ReleaseDate = new DateTime(2009, 10, 20),
                    DateAdded = DateTime.Now,
                    NumberAvailable = 12,
                }},
            };


        enum GenreId
        {
            Action = 1,
            Comedy = 2,
            Drama = 3,
            Fantasy = 4,
            Horror = 5,
            Romance = 6,
            Thriller = 7
        }

        private static Dictionary<GenreId, Genre> Genres = new Dictionary<GenreId, Genre>()
        {
            {GenreId.Action, new Genre() {Id = 1, Name = "Action"}},
            {GenreId.Comedy, new Genre() {Id = 2, Name = "Comedy"}},
            {GenreId.Drama, new Genre() {Id = 3, Name = "Drama"}},
            {GenreId.Fantasy, new Genre() {Id = 4, Name = "Fantasy"}},
            {GenreId.Horror, new Genre() {Id = 5, Name = "Horror"}},
            {GenreId.Romance, new Genre() {Id = 6, Name = "Romance"}},
            {GenreId.Thriller, new Genre() {Id = 7, Name = "Thriller"}},
        };
    }
}