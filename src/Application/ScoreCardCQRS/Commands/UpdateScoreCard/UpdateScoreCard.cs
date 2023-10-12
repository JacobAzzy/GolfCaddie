using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.UpdateScoreCard;

public record UpdateScoreCardListCommand : IRequest
{
    public int Id { get; init; }
    public SaveScoreCardVM? scoreCard { get; init; }
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
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.UserId = request.scoreCard.UserId;
        entity.Id = request.Id;
        entity.CourseName = request.scoreCard.CourseName;
        entity.Date = request.scoreCard.Date;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
