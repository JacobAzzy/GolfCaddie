namespace GolfCaddie.Application.Common.Models;

public class HoleDto
{
    public required int HoleNumber { get; set; }
    public required int Par { get; set; }
    public required int Score { get; set; }
    public int Putts { get; set; }
    public int Penalties { get; set; }
}
