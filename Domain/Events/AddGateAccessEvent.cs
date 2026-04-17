using Domain.Common;
using Domain.Entities;

namespace Domain.Events
{
    public class AddGateAccessEvent : EventBase
    {
        public required GateAccess GateAccess { get; set; }
    }
}
