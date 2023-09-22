using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;

public record CreateScoreCardCommand : IRequest<ScoreCardDto>
{
    public SaveScoreCardVM scoreCard { get; init; }
}

public class CreateScoreCardCommandHandler : IRequestHandler<CreateScoreCardCommand, ScoreCardDto>
{
    private readonly IApplicationDbContext _context;

    public CreateScoreCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ScoreCardDto> Handle(CreateScoreCardCommand request, CancellationToken cancellationToken)
    {
        var entity = new ScoreCardDto
        { 
            id = request.scoreCard.id,
            CourseName = request.scoreCard.CourseName,
            Date = request.scoreCard.Date,
            Holes = request.scoreCard.Holes
        };

        _context.ScoreCards.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
