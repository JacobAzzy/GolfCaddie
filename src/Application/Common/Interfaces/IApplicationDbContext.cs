using GolfCaddie.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GolfCaddie.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ScoreCard> TodoLists { get; }

    DbSet<Hole> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
