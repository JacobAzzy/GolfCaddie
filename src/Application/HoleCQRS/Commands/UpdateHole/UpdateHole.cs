﻿using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.HoleCQRS.Commands.CreateHole;

namespace GolfCaddie.Application.HoleCQRS.Commands.UpdateHole;

public record UpdateHoleCommand : IRequest
{
    public int Id { get; init; }
    public SaveHoleVM? hole { get; init; }
}

public class UpdateHoleCommandHandler : IRequestHandler<UpdateHoleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateHoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateHoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Holes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.ScoreCardId = request.hole.ScoreCardId;
        entity.HoleNumber = request.hole.HoleNumber;
        entity.Par = request.hole.Par;  
        entity.Putts = request.hole.Putts;
        entity.Score = request.hole.Score;
        entity.Penalties = request.hole.Penalties;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
