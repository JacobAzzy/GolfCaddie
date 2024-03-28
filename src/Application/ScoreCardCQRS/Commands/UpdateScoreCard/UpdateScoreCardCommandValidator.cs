﻿using GolfCaddie.Application.Common.Interfaces;

namespace GolfCaddie.Application.ScoreCardCQRS.Commands.UpdateScoreCard;

public class UpdateHoleCommandValidator : AbstractValidator<UpdateScoreCardCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateHoleCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.scoreCardDto.CourseName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(v => v.scoreCardDto.Holes)
            .NotEmpty();

        RuleFor(v => v.scoreCardDto.Date)
            .NotEmpty();
    }

    public async Task<bool> BeUniqueTitle(UpdateScoreCardCommand model, int Id, CancellationToken cancellationToken)
    {
        return await _context.ScoreCards
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Id != Id, cancellationToken);
    }
}
