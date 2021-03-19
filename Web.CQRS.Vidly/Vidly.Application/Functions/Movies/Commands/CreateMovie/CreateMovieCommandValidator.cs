using FluentValidation;

namespace Vidly.Application.Functions.Movies.Commands.CreateMovie
{
	public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
	{
		#region Constructors

		public CreateMovieCommandValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty()
				.WithMessage("{PropertyName} is required")
				.NotNull()
				.MaximumLength(80)
				.WithMessage("{PropertyName} must not exceed 80 characters");


			RuleFor(p => p.ReleaseDate)
				.NotEmpty()
				.WithMessage("{PropertyName} is required")
				.NotNull();

			RuleFor(p => p.Count)
				.GreaterThan((short)0);
		}

		#endregion Constructors
	}
}