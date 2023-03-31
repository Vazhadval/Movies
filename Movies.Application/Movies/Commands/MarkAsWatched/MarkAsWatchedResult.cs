namespace Movies.Application.Movies.Commands.MarkAsWatched
{
    public class MarkAsWatchedResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string MovieTitle { get; set; }
    }
}
