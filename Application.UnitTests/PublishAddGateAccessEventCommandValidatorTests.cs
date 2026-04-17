using Application.Gates.Commands.PublishAddGateAccessEvent;
using FluentValidation.TestHelper;

namespace Application.UnitTests
{
    public class PublishAddGateAccessEventCommandValidatorTests
    {
        private readonly PublishAddGateAccessEventCommandValidator validator;

        public PublishAddGateAccessEventCommandValidatorTests()
        {
            validator = new();
        }

        [Fact]
        public void ShouldHaveValidationErrors_WhenCommandIsInvalid()
        {
            var command = new PublishAddGateAccessEventCommand
            {
                Gate = "Gate A",
                NumberOfPeople = -1
            };

            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.NumberOfPeople);
        }

        [Fact]
        public void ShouldNotHaveAnyValidationErrors_WhenCommandIsValid()
        {
            var command = new PublishAddGateAccessEventCommand
            {
                Gate = "Gate A",
                NumberOfPeople = 1
            };

            var result = validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
