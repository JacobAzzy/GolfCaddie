using GolfCaddie.Application.Common.Models;

namespace GolfCaddie.Application.ScoreCardCQRS.Queries.GetScoreCard;

public class ScoreCardHistoryVM
{
    public IReadOnlyCollection<ScoreCardDto> ScoreCards { get; init; } = Array.Empty<ScoreCardDto>();
}
