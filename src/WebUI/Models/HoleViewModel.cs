using System.ComponentModel.DataAnnotations;

namespace GolfCaddie.WebUI.Models;

public class HoleViewModel
{
    public required int HoleNumber { get; set; }
    public required int Par { get; set; }
    public required int Score { get; set; }
    public int Putts { get; set; }
    public int Penalties { get; set; }
}

