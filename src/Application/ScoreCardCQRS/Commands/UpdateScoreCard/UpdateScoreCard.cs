using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.UpdateScoreCard;

public record UpdateScoreCardCommand : IRequest<ScoreCard>
{
    public int Id { get; set; }
    public SaveScoreCardVM? scoreCard { get; set; }
}

public class UpdateScoreCardCommandHandler : IRequestHandler<UpdateScoreCardCommand, ScoreCard>
{
    private readonly IApplicationDbContext _context;

    public UpdateScoreCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ScoreCard> Handle(UpdateScoreCardCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ScoreCards
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.UserId = request.scoreCard.UserId;
        entity.Id = request.Id;
        entity.CourseName = request.scoreCard.CourseName;
        entity.Date = request.scoreCard.Date;

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
