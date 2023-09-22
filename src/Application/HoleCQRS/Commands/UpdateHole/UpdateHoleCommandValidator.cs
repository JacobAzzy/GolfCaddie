using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.HoleCQRS.Commands.UpdateHole;

public class UpdateHoleCommandValidator : AbstractValidator<UpdateHoleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateHoleCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.hole.id)
            .NotEmpty();

        RuleFor(v => v.hole.Par)
            .NotEmpty();

        RuleFor(v => v.hole.HoleNumber)
            .NotEmpty();

        RuleFor(v => v.hole.Score)
            .NotEmpty();
    }

    public async Task<bool> BeUniqueTitle(UpdateHoleCommand model, string title, CancellationToken cancellationToken)
    {
        return await _context.Holes
            .Where(l => l.id != model.hole.id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
