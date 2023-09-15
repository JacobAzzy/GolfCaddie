using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<Hole> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
