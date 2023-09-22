using GolfCaddie.Application.Common.Models;

namespace GolfCaddie.Application.HoleCQRS.Queries.GetHole;

public class HoleHistoryVM
{
    public IReadOnlyCollection<HoleDto> Holes { get; init; } = Array.Empty<HoleDto>();
}
