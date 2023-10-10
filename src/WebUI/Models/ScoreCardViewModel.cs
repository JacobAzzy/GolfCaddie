using System.ComponentModel.DataAnnotations;

namespace GolfCaddie.WebUI.Models;

public class ScoreCardViewModel
{
    [Required]
    public required string CourseName { get; set; }
    public DateTime Date { get; set; }
    [Required]
    public List<HoleViewModel>? Holes { get; set; }
}

