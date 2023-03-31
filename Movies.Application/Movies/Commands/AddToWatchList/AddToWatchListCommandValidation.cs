using FluentValidation;

namespace Movies.Application.Movies.Commands.AddToWatchList
{
    public class AddToWatchListCommandValidation : AbstractValidator<AddToWatchListCommand>
    {
        public AddToWatchListCommandValidation()
        {
            RuleFor(v => v.MovieId)
                .NotEmpty();

            RuleFor(v => v.UserId)
                .NotEmpty();

            RuleFor(v => v.UserId)
                .GreaterThan(0);
        }
    }
}
