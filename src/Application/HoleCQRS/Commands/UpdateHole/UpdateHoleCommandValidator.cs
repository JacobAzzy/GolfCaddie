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

    public async Task<bool> BeUniqueTitle(UpdateHoleCommand model, int Id, CancellationToken cancellationToken)
    {
        return await _context.Holes
            .Where(l => l.id != model.hole.id)
            .AllAsync(l => l.id != Id, cancellationToken);
    }
}
