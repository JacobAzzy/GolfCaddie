using GolfCaddie.Application.Common.Models;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;

public class SaveScoreCardVM
{
    public int id { get; set; }
    public required string CourseName { get; set; }
    public DateTime Date { get; set; }
    public List<Hole> Holes { get; set; }
}
