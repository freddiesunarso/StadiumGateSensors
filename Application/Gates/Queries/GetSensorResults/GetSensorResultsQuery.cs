using MediatR;

namespace Application.Gates.Queries.GetSensorResults;

public record GetSensorResultsQuery : IRequest<IEnumerable<SensorResult>>
{
    public string? Gate { get; set; }

    public string? Type { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }
};
