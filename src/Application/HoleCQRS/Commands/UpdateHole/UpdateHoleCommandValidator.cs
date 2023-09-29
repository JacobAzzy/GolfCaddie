using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.HoleCQRS.Commands.UpdateHole;

public class UpdateHoleCommandValidator : AbstractValidator<UpdateHoleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateHoleCommandValidator(IApplicationDbContext context)
    {
        _context = context;
         if (context != null) 
        {
            RuleFor(v => v.hole.Par)
                .NotEmpty();

            RuleFor(v => v.hole.HoleNumber)
                .NotEmpty();

            RuleFor(v => v.hole.Score)
                .NotEmpty();
        }

    }

    public async Task<bool> BeUniqueTitle(UpdateHoleCommand model, int Id, CancellationToken cancellationToken)
    {
        return await _context.Holes
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Id != Id, cancellationToken);
    }
}
