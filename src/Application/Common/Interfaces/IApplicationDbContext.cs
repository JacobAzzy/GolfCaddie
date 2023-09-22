using GolfCaddie.Application.Common.Models;
using GolfCaddie.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GolfCaddie.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ScoreCardDto> ScoreCards { get; }

    DbSet<HoleDto> Holes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
