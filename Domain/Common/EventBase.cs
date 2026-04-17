using MediatR;

namespace Domain.Common;

public abstract class EventBase : INotification
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
}
