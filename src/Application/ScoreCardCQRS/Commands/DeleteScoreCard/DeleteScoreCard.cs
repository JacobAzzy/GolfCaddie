using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.DeleteScoreCard;


public record DeleteScoreCardCommand(int Id) : IRequest<bool>;

public class DeleteScoreCardCommandHandler : IRequestHandler<DeleteScoreCardCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteScoreCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteScoreCardCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.ScoreCards
           .Where(l => l.Id == request.Id)
           .SingleOrDefaultAsync(cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            _context.ScoreCards.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
