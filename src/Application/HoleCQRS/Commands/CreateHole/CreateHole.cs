using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.HoleCQRS.Commands.CreateHole;

public record CreateHoleCommand : IRequest<int>
{
    public required SaveHoleVM hole { get; init; }
}

public class CreateHoleCommandHandler : IRequestHandler<CreateHoleCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateHoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateHoleCommand request, CancellationToken cancellationToken)
    {
        // simplify and test
        var entity = new Hole
        {
            ScoreCardId = request.hole.ScoreCardId,
            HoleNumber = request.hole.HoleNumber,
            Par = request.hole.Par,
            Score = request.hole.Score,
            Putts = request.hole.Putts,
            Penalties = request.hole.Penalties
        };

        _context.Holes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
