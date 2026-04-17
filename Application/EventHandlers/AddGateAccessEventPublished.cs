using Application.Common.Interfaces;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.EventHandlers
{
    public class AddGateAccessEventPublished(ILogger<AddGateAccessEventPublished> logger, IGateAccessDbContext dbContext) : INotificationHandler<AddGateAccessEvent>
    {
        public async Task Handle(AddGateAccessEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                await dbContext.GateAccesses.AddAsync(notification.GateAccess, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                logger.LogError(e, "{className}.{methodName} Failed to store gate access event {messageId}", nameof(AddGateAccessEventPublished), nameof(Handle), notification.MessageId);
            }
        }
    }
}
