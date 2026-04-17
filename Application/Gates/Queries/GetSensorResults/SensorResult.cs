using Domain.Entities;

namespace Application.Gates.Queries.GetSensorResults
{
    public class SensorResult
    {
        public required string Gate { get; set; }

        public GateAccessType Type { get; set; }

        public int NumberOfPeople { get; set; }
    }
}
