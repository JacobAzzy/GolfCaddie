using GolfCaddie.Domain.Common;

namespace GolfCaddie.Domain.Entities;

public class ScoreCard : BaseAuditableEntity
{
    public int id { get; set; }
    public required string CourseName { get; set; }
    public DateTime Date { get; set; }
}
