using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.Common.Models;

public class ScoreCardDto
{
    public int id { get; set; }
    public required string CourseName { get; set; }
    public DateTime Date { get; set; }
    public List<Hole> Holes { get; set; }
}
