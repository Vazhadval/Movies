using Domain.Entities;
using MediatR;
using Movies.Application.Common.Exceptions;
using Movies.Application.Common.Interfaces;

namespace Movies.Application.Movies.Commands.AddToWatchList
{
    public record AddToWatchListCommand : IRequest<AddToWatchListResult>
    {
        public string MovieId { get; init; }

        public int UserId { get; init; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<AddToWatchListCommand, AddToWatchListResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IImdbService _imdbService;

        public CreateTodoItemCommandHandler(IApplicationDbContext context, IImdbService imdbService)
        {
            _context = context;
            _imdbService = imdbService;
        }

        public async Task<AddToWatchListResult> Handle(AddToWatchListCommand request, CancellationToken cancellationToken)
        {
            var movie = await _imdbService.GetSingleMovieById(request.MovieId);
            if (movie?.Id == null)
            {
                throw new NotFoundException("Movie was not found in imdb service");
            }

            var isAlreadyInWatchList = _context.WatchListItems.Any(x => x.UserID == request.UserId && x.MovieID == movie.Id);
            if (isAlreadyInWatchList)
            {
                return new AddToWatchListResult
                {
                    Added = false,
                    Message = "already in watchlist"
                };
            }

            var entity = new WatchListItem
            {
                MovieID = movie.Id,
                MovieTitle = movie.Title,
                MoviePlot = movie.Plot,
                MovieImage = movie.Image,
                UserID = request.UserId,
                IsWatched = false
            };

            _context.WatchListItems.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddToWatchListResult
            {
                Added = true,
                Message = "movie was added to watchlist"
            };
        }
    }
}
