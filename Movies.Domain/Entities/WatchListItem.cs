using Movies.Domain.Common;

namespace Domain.Entities
{
    public class WatchListItem : BaseAuditableEntity
    {
        public int UserID { get; set; }
        public string MovieID { get; set; }
        public string MovieTitle { get; set; }
        public string MoviePlot { get; set; }
        public string MovieImage { get; set; }
        public bool IsWatched { get; set; }
    }
}
