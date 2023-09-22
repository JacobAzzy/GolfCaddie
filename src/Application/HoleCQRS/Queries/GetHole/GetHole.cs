using GolfCaddie.Application.Common.Interfaces;
using GolfCaddie.Application.Common.Models;
using GolfCaddie.Application.Common.Security;
using GolfCaddie.Domain.Entities;

namespace GolfCaddie.Application.HoleCQRS.Queries.GetHole;

[Authorize]
public record GetHoleQuery : IRequest<HoleHistoryVM>;

public class GetHoleQueryHandler : IRequestHandler<GetHoleQuery, HoleHistoryVM>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetHoleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<HoleHistoryVM> Handle(GetHoleQuery request, CancellationToken cancellationToken)
    {
        return new HoleHistoryVM
        {
            // implement
            Holes = new List<HoleDto>()
        };
    }
}
