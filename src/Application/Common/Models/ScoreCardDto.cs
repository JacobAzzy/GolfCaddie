namespace GolfCaddie.Application.Common.Models;

public class ScoreCardDto
{
    public required List<HoleDto> Hole { get; set; }
    public required string CourseName { get; set; }
    public DateTime Date { get; set; }
}
