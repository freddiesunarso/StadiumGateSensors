using AutoMapper;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Gates.Commands.PublishAddGateAccessEvent
{
    public class PublishAddGateAccessEventCommandHandler(IMapper mapper, IMediator mediator) : IRequestHandler<PublishAddGateAccessEventCommand>
    {
        public async Task Handle(PublishAddGateAccessEventCommand command, CancellationToken cancellationToken)
        {
            var addGateAccessEvent = new AddGateAccessEvent
            {
                GateAccess = mapper.Map<GateAccess>(command)
            };

            await mediator.Publish(addGateAccessEvent, cancellationToken);
        }
    }
}
