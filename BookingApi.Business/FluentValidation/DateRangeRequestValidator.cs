using BookingApi.Core.Models.Request;
using FluentValidation;

namespace BookingApi.Business.FluentValidation
{
    public class DateRangeRequestValidator : AbstractValidator<DateRangeRequest>
    {
        public DateRangeRequestValidator()
        {
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("StartDate cannot be greater than EndDate.");

            RuleFor(x => x.StartDate)
               .NotEmpty()
               .WithMessage("StartDate cannot be empty");

            RuleFor(x => x.EndDate)
               .NotEmpty()
               .WithMessage("EndDate cannot be empty");

            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Today.AddDays(-1))
                .WithMessage("StartDate cannot be in the past");

            RuleFor(x => x.EndDate)
                .LessThanOrEqualTo(DateTime.Today.AddMonths(3))
                .WithMessage("EndDate cannot be far in the future.");
        }
    }
}
