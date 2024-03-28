using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Application.Common.Security;

namespace GolfCaddie.Application.ScoreCardCQRS.Queries.GetScoreCard;

[Authorize]
public record GetScoreCardByIdQuery : IRequest<ScoreCardDto>
{
    public int ScoreCardId { get; set; }
}

public class GetScoreCardByIdQueryHandler : IRequestHandler<GetScoreCardByIdQuery, ScoreCardDto>
{
    private readonly IApplicationDbContext _context;

    public GetScoreCardByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ScoreCardDto> Handle(GetScoreCardByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var scoreCard = await _context.ScoreCards.Include(scorecard => scorecard.Holes.OrderBy(hole => hole.HoleNumber))
                .FirstOrDefaultAsync(x => x.Id == request.ScoreCardId);
            if (scoreCard == null)
            {
                return null;
            }

            var scoreCardDto = new ScoreCardDto()
            {
                ScoreCardId = scoreCard.Id,
                UserId = scoreCard.UserId,
                CourseName = scoreCard.CourseName,
                Date = scoreCard.Date,
                Holes = scoreCard.Holes?.Select(hole => new HoleDto()
                {
                    HoleNumber = hole.HoleNumber,
                    Par = hole.Par,
                    Score = hole.Score,
                    Putts = hole.Putts,
                    Penalties = hole.Penalties
                }).ToList()
            };

            return scoreCardDto;
        }

        catch (Exception)
        {
            throw;
        }
    }
}
