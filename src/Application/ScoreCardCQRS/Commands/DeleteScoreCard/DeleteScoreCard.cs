using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.DeleteScoreCard;


public record DeleteScoreCardCommand(int id) : IRequest;

public class DeleteScoreCardCommandHandler : IRequestHandler<DeleteScoreCardCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteScoreCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteScoreCardCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ScoreCards
            .Where(l => l.id == request.id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.id, entity);

        _context.ScoreCards.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
