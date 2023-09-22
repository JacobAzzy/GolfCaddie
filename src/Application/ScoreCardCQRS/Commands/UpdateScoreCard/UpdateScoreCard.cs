using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.UpdateScoreCard;

public record UpdateScoreCardListCommand : IRequest
{
    public SaveScoreCardVM scoreCard { get; init; }
}

public class UpdateScoreCardListCommandHandler : IRequestHandler<UpdateScoreCardListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateScoreCardListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateScoreCardListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ScoreCards
            .FindAsync(new object[] { request.scoreCard.id }, cancellationToken);

        Guard.Against.NotFound(request.scoreCard.id, entity);

        entity.id = request.scoreCard.id;
        entity.CourseName = request.scoreCard.CourseName;
        entity.Holes = request.scoreCard.Holes;
        entity.Date = request.scoreCard.Date;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
