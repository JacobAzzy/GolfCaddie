using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Application.Common.Security;

namespace GolfCaddie.Application.ScoreCardCQRS.Queries.GetScoreCard;

[Authorize]
public record GetScoreCardsQuery : IRequest<ScoreCardHistoryVM>;

public class GetScoreCardsQueryHandler : IRequestHandler<GetScoreCardsQuery, ScoreCardHistoryVM>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetScoreCardsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<ScoreCardHistoryVM> Handle(GetScoreCardsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new ScoreCardHistoryVM
        {
            // implement
            ScoreCards = new List<ScoreCardDto> { }
        });
    }
}
