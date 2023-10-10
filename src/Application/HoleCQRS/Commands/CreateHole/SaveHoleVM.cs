using GolfCaddie.Application.Common.Models;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.HoleCQRS.Commands.CreateHole;

public class SaveHoleVM
{
    public required int ScoreCardId { get; set; }
    public required int HoleNumber { get; set; }
    public required int Par { get; set; }
    public required int Score { get; set; }
    public int Putts { get; set; }
    public int Penalties { get; set; }
}
