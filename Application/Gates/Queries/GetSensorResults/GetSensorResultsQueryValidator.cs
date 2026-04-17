using Domain.Entities;
using FluentValidation;

namespace Application.Gates.Queries.GetSensorResults
{
    public class GetSensorResultsQueryValidator : AbstractValidator<GetSensorResultsQuery>
    {
        public GetSensorResultsQueryValidator()
        {
            RuleFor(g => g)
                .Must(g => g.Gate != null || g.Type != null || g.StartTime != null || g .EndTime != null)
                .WithMessage("At least one of Gate, Type, StartTime, or EndTime must be provided.");

            RuleFor(g => g.Type)
                .Must(s => Enum.TryParse<GateAccessType>(s, true, out _))
                .When(g => !string.IsNullOrWhiteSpace(g.Type))
                .WithMessage("Type must be a valid gate access type.");

            RuleFor(g => g.StartTime)
                .Must(s => DateTime.TryParse(s, out _))
                .When(g => !string.IsNullOrWhiteSpace(g.StartTime))
                .WithMessage("StartTime must be a valid date and time.");

            RuleFor(g => g.EndTime)
                .Must(s => DateTime.TryParse(s, out _))
                .When(g => !string.IsNullOrWhiteSpace(g.EndTime))
                .WithMessage("EndTime must be a valid date and time.");
        }
    }
}
