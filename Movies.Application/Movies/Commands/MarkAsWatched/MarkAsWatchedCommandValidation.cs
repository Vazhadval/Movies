using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
