using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;
using GolfCaddie.Domain.Entities;
using MediatR.NotificationPublishers;
using static System.Formats.Asn1.AsnWriter;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.UpdateScoreCard;

public record UpdateScoreCardCommand : IRequest<ScoreCard>
{
    public required int Id { get; set; }
    public required ScoreCardDto scoreCardDto { get; set; }
}

public class UpdateScoreCardCommandHandler : IRequestHandler<UpdateScoreCardCommand, ScoreCard>
{
    private readonly IApplicationDbContext _context;

    public UpdateScoreCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ScoreCard> Handle(UpdateScoreCardCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.ScoreCards.Include(holes => holes.Holes).FirstOrDefaultAsync(scoreCard => scoreCard.Id == request.Id);

            Guard.Against.NotFound(request.Id, entity);

            entity.Holes = entity.Holes.OrderBy(hole => hole.HoleNumber).ToList();

            entity.CourseName = request.scoreCardDto.CourseName;
            entity.Date = request.scoreCardDto.Date;

            if (request.scoreCardDto.Holes != null)
            {
                int holeNumber = 1;
                for (int i = 0; i < request.scoreCardDto.Holes.Count(); i++)
                {
                    if (request.scoreCardDto.Holes[i].Par == 0)
                    {
                        request.scoreCardDto.Holes.RemoveAt(i);
                        i--; // the next hole could be null so we check the same spot again
                    }
                    else
                    {
                        request.scoreCardDto.Holes[i].HoleNumber = holeNumber;
                    }
                    holeNumber++;
                }
            }

            var scoreCardDtoHoles = request.scoreCardDto.Holes.ToList();

            // Delete entity hole
            var holeList = entity.Holes.ToList();
            entity.Holes.RemoveRange(0, entity.Holes.Count);
            _context.Holes.RemoveRange(holeList);

            await _context.SaveChangesAsync(cancellationToken);

            for (int i = 0; i < scoreCardDtoHoles.Count; i++)
            {
                var newHole = new Hole()
                {
                    ScoreCardId = entity.Id,
                    HoleNumber = scoreCardDtoHoles[i].HoleNumber,
                    Par = scoreCardDtoHoles[i].Par,
                    Score = scoreCardDtoHoles[i].Score,
                    Putts = scoreCardDtoHoles[i].Putts,
                    Penalties = scoreCardDtoHoles[i].Penalties
                };
                entity.Holes.Add(newHole);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}
