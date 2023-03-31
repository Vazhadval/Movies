using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Movies.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<WatchListItem> WatchListItems { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
