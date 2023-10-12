using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ScoreCard> ScoreCards { get; }

    DbSet<Hole> Holes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
