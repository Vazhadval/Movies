using FluentValidation;

namespace Movies.Application.Movies.Queries.GetWatchListItems
{
    public class GetWatchListItemsQueryValidation : AbstractValidator<GetWatchListItemsQuery>
    {
        public GetWatchListItemsQueryValidation()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
