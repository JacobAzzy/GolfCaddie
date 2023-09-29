using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;

public record CreateScoreCardCommand : IRequest<int>
{
    public SaveScoreCardVM? scoreCard { get; init; }
}

public class CreateScoreCardCommandHandler : IRequestHandler<CreateScoreCardCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateScoreCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateScoreCardCommand request, CancellationToken cancellationToken)
    {
        var entity = new ScoreCard
        { 
            CourseName = request.scoreCard.CourseName,
            Date = request.scoreCard.Date,
            Holes = request.scoreCard.Holes,
        };

        _context.ScoreCards.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
