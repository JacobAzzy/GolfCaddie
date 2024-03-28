using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Application.Common.Security;

namespace GolfCaddie.Application.ScoreCardCQRS.Queries.GetScoreCard;

[Authorize]
public record GetAllScoreCardsQuery : IRequest<List<ScoreCardDto>>;

public class GetAllScoreCardsQueryHandler : IRequestHandler<GetAllScoreCardsQuery, List<ScoreCardDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllScoreCardsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ScoreCardDto>> Handle(GetAllScoreCardsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var scoreCards = await _context.ScoreCards.OrderByDescending(x => x.Date).Include(scorecard => scorecard.Holes.OrderBy(hole => hole.HoleNumber)).ToListAsync();
            return scoreCards.Select(scoreCard => new ScoreCardDto() 
            {
                ScoreCardId = scoreCard.Id, 
                UserId = scoreCard.UserId,
                CourseName = scoreCard.CourseName,
                Holes = scoreCard.Holes.Select(hole => new HoleDto()
                { 
                    HoleNumber = hole.HoleNumber,
                    Par = hole.Par,
                    Score = hole.Score,
                    Putts = hole.Putts,
                    Penalties = hole.Penalties
                }).ToList(),
                Date = scoreCard.Date
            }).ToList();       
        }

        catch (Exception)
        {
            throw;
        }
    }
}
