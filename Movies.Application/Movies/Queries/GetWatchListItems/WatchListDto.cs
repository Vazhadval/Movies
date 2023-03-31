using Domain.Entities;
using Movies.Application.Common.Mappings;

namespace Movies.Application.Movies.Queries.GetWatchListItems
{
    public class WatchListItemDto : IMapFrom<WatchListItem>
    {
        public string MovieID { get; set; }
        public string MovieTitle { get; set; }
        public string MoviePlot { get; set; }
        public string MovieImage { get; set; }
        public bool IsWatched { get; set; }
    }
}
