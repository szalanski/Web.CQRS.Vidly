using System;
using MediatR;

using Vidly.Application.Functions.Movies.Commands.CreateMovie;

namespace Vidly.Application.Functions.Movies.Commands
{
	public class CreateMovieCommand : IRequest<CreateMovieCommandResponse>
	{
		#region Public Properties

		public string Name { get; set; }

		public DateTime ReleaseDate { get; set; }

		public DateTime DateAdded { get; set; }

		public short Count { get; set; }

		public short NumberAvailable { get; set; }

		public int GenreId { get; set; }

		#endregion Public Properties
	}
}