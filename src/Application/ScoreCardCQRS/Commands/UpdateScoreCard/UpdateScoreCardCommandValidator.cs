using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.UpdateScoreCard;

public class UpdateHoleCommandValidator : AbstractValidator<UpdateScoreCardListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateHoleCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.scoreCard.CourseName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(v => v.scoreCard.Holes)
            .NotEmpty();

        RuleFor(v => v.scoreCard.Date)
            .NotEmpty();
    }

    public async Task<bool> BeUniqueTitle(UpdateScoreCardListCommand model, int Id, CancellationToken cancellationToken)
    {
        return await _context.ScoreCards
            .Where(l => l.id != model.scoreCard.id)
            .AllAsync(l => l.id != Id, cancellationToken);
    }
}
