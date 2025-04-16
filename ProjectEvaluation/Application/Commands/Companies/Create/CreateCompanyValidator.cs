using Domain.Validation;
using FluentValidation;

namespace Application.Commands.Companies.Create
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.CNPJ).SetValidator(new CNPJValidator());
            RuleForEach(x => x.ContactUser).SetValidator(new UserValidator());
            RuleForEach(x => x.Phones).SetValidator(new PhoneValidator());
        }
    }
}