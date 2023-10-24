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
    private readonly IMapper _mapper;

    public GetScoreCardByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ScoreCardDto> Handle(GetScoreCardByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var scoreCard = await _context.ScoreCards.FindAsync(request.ScoreCardId);
            if (scoreCard == null)
            {
                return null;
            }

            var scoreCardDto = _mapper.Map<ScoreCardDto>(scoreCard);
            return scoreCardDto;
        }

        catch (Exception)
        {
            throw;
        }
    }
}
