using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;

public class CreateScoreCardCommandValidator : AbstractValidator<CreateScoreCardCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateScoreCardCommandValidator(IApplicationDbContext context)
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
}
