using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Common.Interfaces;

namespace Movies.Application.Movies.Queries.GetWatchListItems
{
    public class GetWatchListItemsQuery : IRequest<List<WatchListItemDto>>
    {
        public int UserId { get; set; }
    }

    public class GetWatchListItemsQueryHandler : IRequestHandler<GetWatchListItemsQuery, List<WatchListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetWatchListItemsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<WatchListItemDto>> Handle(GetWatchListItemsQuery request, CancellationToken cancellationToken)
        {
            var movies = await _context.WatchListItems.Where(x => x.UserID == request.UserId).ToListAsync();
            return _mapper.Map<List<WatchListItemDto>>(movies);
        }
    }
}
