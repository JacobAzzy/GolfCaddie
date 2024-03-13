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
            //TODO: Change to actual userId once implemented
            request.scoreCardDto.UserId = "61d3f46d-8748-4485-aece-0a94d36f8b00";

            if (request.scoreCardDto.Holes != null)
            {
                int holeNumber = 1;
                for (int i = 0; i < request.scoreCardDto.Holes.Count(); i++)
                {
                    if (request.scoreCardDto.Holes[i].Par == 0)
                    {
                        request.scoreCardDto.Holes.RemoveAt(i);
                        i--; // the next hole could be null so we check the same spot again
                    }
                    else
                    {
                        request.scoreCardDto.Holes[i].HoleNumber = holeNumber;                        
                    }
                    holeNumber++;
                }
            }

            var scoreCard = new ScoreCard
            {
                UserId = request.scoreCardDto.UserId,
                CourseName = request.scoreCardDto.CourseName,
                Date = request.scoreCardDto.Date
            };

            scoreCard.Holes = request.scoreCardDto.Holes.Select(hole => new Hole()
            {
                ScoreCardId = scoreCard.Id,
                HoleNumber = hole.HoleNumber,
                Par = hole.Par,
                Score = hole.Score,
                Putts = hole.Putts,
                Penalties = hole.Penalties
            }).ToList();

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
