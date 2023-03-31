namespace Movies.Application.Common.Interfaces
{
    public interface IWatchListService
    {
        Task<bool> IsMovieAlreadyInUsersWatchList(int userId, string movieId);
    }
}
