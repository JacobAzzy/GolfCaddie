using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;

public record CreateScoreCardCommand : IRequest<int>
{
    //public SaveScoreCardVM? scoreCard { get; set; }
    public required ScoreCardDto scoreCardDto { get; set; }
}

public class CreateScoreCardCommandHandler : IRequestHandler<CreateScoreCardCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateScoreCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateScoreCardCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var scoreCard = new ScoreCard
            {
                UserId = "", // ???
                Id = request.scoreCardDto.id,
                CourseName = request.scoreCardDto.CourseName,
                Date = request.scoreCardDto.Date,
                Holes = request.scoreCardDto.Holes
            };

            _context.ScoreCards.Add(scoreCard);
            await _context.SaveChangesAsync(cancellationToken);

            return scoreCard.Id;
        }

        catch (Exception)
        {
            throw;
        }
    }
}
