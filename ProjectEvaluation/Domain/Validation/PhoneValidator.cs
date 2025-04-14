using Domain.Entities;
using FluentValidation;

namespace Domain.Validation
{
    public class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone.Number)
                .NotEmpty().WithMessage("The phone cannot be empty.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("The phone format is not valid.");
        }
    }

}
