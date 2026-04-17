using Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Gates.Commands.PublishAddGateAccessEvent
{
    public record PublishAddGateAccessEventCommand : IRequest
    {
        public required string Gate { get; set; }

        public DateTime Timestamp { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GateAccessType Type { get; set; }

        public int NumberOfPeople { get; set; }
    }
}
