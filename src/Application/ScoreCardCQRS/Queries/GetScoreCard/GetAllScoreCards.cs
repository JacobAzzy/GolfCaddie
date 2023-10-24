using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Application.Common.Security;

namespace GolfCaddie.Application.ScoreCardCQRS.Queries.GetScoreCard;

[Authorize]
public record GetAllScoreCardsQuery : IRequest<List<ScoreCardDto>>;

public class GetAllScoreCardsQueryHandler : IRequestHandler<GetAllScoreCardsQuery, List<ScoreCardDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllScoreCardsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ScoreCardDto>> Handle(GetAllScoreCardsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var scoreCards = await _context.ScoreCards.ToListAsync();
            var scoreCardDtos = _mapper.Map<List<ScoreCardDto>>(scoreCards);

            return scoreCardDtos;
        }

        catch (Exception)
        {
            throw;
        }
    }
}
