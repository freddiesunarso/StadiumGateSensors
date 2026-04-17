using Application.Gates.Queries.GetSensorResults;
using FluentValidation.TestHelper;

namespace Application.UnitTests
{
    public class GetSensorResultsQueryValidatorTests
    {
        private readonly GetSensorResultsQueryValidator validator;

        public GetSensorResultsQueryValidatorTests()
        {
            validator = new();
        }

        [Fact]
        public void ShouldHaveValidationErrors_WhenQueryIsInvalid_WithAllFieldsHavingNullValues()
        {
            var query = new GetSensorResultsQuery();

            var result = validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(c => c);
        }

        [Fact]
        public void ShouldHaveValidationErrors_WhenQueryIsInvalid_WithTypeFieldHavingInvalidValue()
        {
            var query = new GetSensorResultsQuery
            {
                Type = "Enter and Exit"
            };

            var result = validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(c => c.Type);
        }

        [Fact]
        public void ShouldNotHaveValidationErrors_WhenQueryIsValid_WithAFieldHavingAValidValue()
        {
            var query = new GetSensorResultsQuery
            {
                Gate = "Gate A"
            };

            var result = validator.TestValidate(query);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
