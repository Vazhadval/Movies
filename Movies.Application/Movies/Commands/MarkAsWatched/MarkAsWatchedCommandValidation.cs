using FluentValidation;

namespace Movies.Application.Movies.Commands.MarkAsWatched
{
    public class MarkAsWatchedCommandValidation : AbstractValidator<MarkAsWatchedCommand>
    {
        public MarkAsWatchedCommandValidation()
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
