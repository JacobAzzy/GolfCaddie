using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.HoleCQRS.Commands.CreateHole;

public record CreateHoleCommand : IRequest<HoleDto>
{
    public SaveHoleVM hole { get; init; }
}

public class CreateHoleCommandHandler : IRequestHandler<CreateHoleCommand, HoleDto>
{
    private readonly IApplicationDbContext _context;

    public CreateHoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HoleDto> Handle(CreateHoleCommand request, CancellationToken cancellationToken)
    {
        var entity = new HoleDto
        {
            id = request.hole.id,
            HoleNumber = request.hole.HoleNumber,
            Par = request.hole.Par,
            Score = request.hole.Score,
            Putts = request.hole.Putts,
            Penalties = request.hole.Penalties
        };

        _context.Holes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
