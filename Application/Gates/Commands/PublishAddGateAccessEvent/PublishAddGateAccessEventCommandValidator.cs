using FluentValidation;

namespace Application.Gates.Commands.PublishAddGateAccessEvent
{
    public class PublishAddGateAccessEventCommandValidator : AbstractValidator<PublishAddGateAccessEventCommand>
    {
        public PublishAddGateAccessEventCommandValidator()
        {
            RuleFor(v => v.NumberOfPeople).GreaterThan(-1);
        }
    }
}
