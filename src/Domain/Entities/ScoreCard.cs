using GolfCaddie.Domain.Common;

namespace GolfCaddie.Domain.Entities;

// Exact replica of database table
public class ScoreCard : BaseAuditableEntity
{
    public required string UserId { get; set; }
    public required string CourseName { get; set; }
    public DateTime Date { get; set; }
    public List<Hole>? Holes { get; set; }
}

// ScoreCard DTO
// Same as Entity

// ScoreCardHistoryVM (ScoreCard VM)
//  List<ScoreCard>
//  Handicap
//  Average Putts
//  Best Game
//  Worst Game
//  Average Game
//  ...