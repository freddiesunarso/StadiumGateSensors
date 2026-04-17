using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Gates.Queries.GetSensorResults;

public class GetSensorResultsQueryHandler(IGateAccessDbContext gateAccessDbContext) : IRequestHandler<GetSensorResultsQuery, IEnumerable<SensorResult>>
{
    public async Task<IEnumerable<SensorResult>> Handle(GetSensorResultsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<GateAccess> query = gateAccessDbContext.GateAccesses;
        
        if (!string.IsNullOrWhiteSpace(request.Gate))
        {
            query = query.Where(g => g.Gate == request.Gate);
        }

        if (!string.IsNullOrWhiteSpace(request.Type) && Enum.TryParse<GateAccessType>(request.Type, true, out var gateAccessType))
        {
            query = query.Where(g => g.Type == gateAccessType);
        }

        if (!string.IsNullOrWhiteSpace(request.StartTime) && DateTime.TryParse(request.StartTime, out var startTime))
        {
            query = query.Where(g => g.Timestamp >= startTime);
        }
        if (!string.IsNullOrWhiteSpace(request.EndTime) && DateTime.TryParse(request.EndTime, out var endTime))
        {
            query = query.Where(g => g.Timestamp <= endTime);
        }

        return await query
            .GroupBy(sr => new { sr.Gate, sr.Type })
            .Select(g => new SensorResult
            {
                Gate = g.Key.Gate,
                Type = g.Key.Type,
                NumberOfPeople = g.Sum(sr => sr.NumberOfPeople)
            })
            .ToListAsync(cancellationToken);
    }
}
