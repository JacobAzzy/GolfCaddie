using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.Common.Models;

public class ScoreCardDto
{
    public required string UserId { get; set; }
    public required string CourseName { get; set; }
    public DateTime Date { get; set; }
    public List<HoleDto>? Holes { get; set; }
}
