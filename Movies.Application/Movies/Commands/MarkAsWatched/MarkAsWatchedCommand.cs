using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Common.Interfaces;

namespace Movies.Application.Movies.Commands.MarkAsWatched
{
    public record MarkAsWatchedCommand : IRequest<MarkAsWatchedResult>
    {
        public string MovieId { get; init; }

        public int UserId { get; init; }
        public bool IsWatched { get; init; } = true;
    }

    public class MarkAsWatchedCommandHandler : IRequestHandler<MarkAsWatchedCommand, MarkAsWatchedResult>
    {
        private readonly IApplicationDbContext _context;

        public MarkAsWatchedCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MarkAsWatchedResult> Handle(MarkAsWatchedCommand request, CancellationToken cancellationToken)
        {
            var watchListItem = await _context.WatchListItems
                .FirstOrDefaultAsync(x => x.UserID == request.UserId && x.MovieID == request.MovieId);

            if (watchListItem == null)
            {
                return new MarkAsWatchedResult
                {
                    IsSuccess = false,
                    Message = "resource was not found",
                };
            }

            if (watchListItem.IsWatched)
            {
                return new MarkAsWatchedResult
                {
                    IsSuccess = false,
                    Message = "movie has already been marked as watched",
                    MovieTitle = watchListItem.MovieTitle
                };
            }

            watchListItem.IsWatched = true;
            await _context.SaveChangesAsync(cancellationToken);

            return new MarkAsWatchedResult
            {
                IsSuccess = true,
                Message = "movie was marked as watched",
                MovieTitle = watchListItem.MovieTitle
            };
        }
    }
}
