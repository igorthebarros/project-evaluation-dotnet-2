using Domain.Entities;
using FluentValidation;

namespace Domain.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email).SetValidator(new EmailValidator());

            RuleFor(user => user.FirstName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long.")
                .MaximumLength(20).WithMessage("First name cannot be longer than 20 characters.");

            RuleFor(user => user.LastName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.")
                .MaximumLength(20).WithMessage("Last name cannot be longer than 20 characters.");

            RuleFor(user => user.Password).SetValidator(new PasswordValidator());

            RuleFor(user => user.Phone)
                .Matches(@"^\+[1-9]\d{10,14}$").WithMessage("Phone number must start with '+' followed by 11-15 digits.");
        }
    }
}   
