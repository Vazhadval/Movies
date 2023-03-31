using FluentValidation;
using Movies.Application.Movies.Queries.SearchMovies;

namespace Application.Movies.Queries.SearchMovies
{
    public class SearchMoviesQueryValidation : AbstractValidator<SearchMoviesQuery>
    {
        public SearchMoviesQueryValidation()
        {
            RuleFor(x => x.SearchTerm)
                .NotEmpty().WithMessage("Search Term must not be empty.");
        }
    }
}
