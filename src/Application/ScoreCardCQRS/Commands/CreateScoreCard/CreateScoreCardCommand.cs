using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;

public record CreateScoreCardCommand : IRequest<int>
{
    //public SaveScoreCardVM? scoreCard { get; set; }
    public required ScoreCardDto scoreCardDto { get; set; }
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
        try
        {
            var scoreCard = new ScoreCard
            {
                UserId = request.scoreCardDto.UserId,
                CourseName = request.scoreCardDto.CourseName,
                Date = request.scoreCardDto.Date,
                Holes = request.scoreCardDto.Holes.Select(hole => new Hole()
                {
                    ScoreCardId = 1,
                    HoleNumber = hole.HoleNumber,
                    Par = hole.Par,
                    Score = hole.Score,
                    Putts = hole.Putts,
                    Penalties = hole.Penalties
                }).ToList()
            };

            _context.ScoreCards.Add(scoreCard);
            await _context.SaveChangesAsync(cancellationToken);

            return scoreCard.Id;
        }

        catch (Exception)
        {
            throw;
        }
    }
}
