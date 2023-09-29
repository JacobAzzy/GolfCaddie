using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.HoleCQRS.Commands.CreateHole;

public class CreateHoleCommandValidator : AbstractValidator<CreateHoleCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateHoleCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.hole.Par)
            .NotEmpty();

        RuleFor(v => v.hole.HoleNumber)
            .NotEmpty();

        RuleFor(v => v.hole.Score)
            .NotEmpty();
    }
}
