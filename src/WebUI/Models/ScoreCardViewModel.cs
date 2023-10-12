using System.ComponentModel.DataAnnotations;

namespace GolfCaddie.WebUI.Models;

public class ScoreCardViewModel
{
    public required string CourseName { get; set; }
    public DateTime Date { get; set; }
    public List<HoleViewModel>? Holes { get; set; }
}

