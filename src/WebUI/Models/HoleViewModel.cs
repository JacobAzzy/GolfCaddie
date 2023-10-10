using System.ComponentModel.DataAnnotations;

namespace GolfCaddie.WebUI.Models;

public class HoleViewModel
{
    [Required]
    public required int HoleNumber { get; set; }
    [Required]
    public required int Par { get; set; }
    [Required]
    public required int Score { get; set; }
    public int Putts { get; set; }
    public int Penalties { get; set; }
}

