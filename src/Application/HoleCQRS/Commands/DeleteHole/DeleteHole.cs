using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.HoleCQRS.Commands.DeleteHole;

public record DeleteHoleCommand(int Id) : IRequest;

public class DeleteHoleCommandHandler : IRequestHandler<DeleteHoleCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteHoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteHoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Holes
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Holes.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
