using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Common.Interfaces
{
    public interface IWatchListService
    {
        Task<bool> IsMovieAlreadyInUsersWatchList(int userId, string movieId);
    }
}
