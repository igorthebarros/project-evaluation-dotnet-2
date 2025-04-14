using Domain.Validation;
using FluentValidation;

namespace Application.Commands.Orders.Create
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Company.CNPJ).SetValidator(new CNPJValidator());
            RuleForEach(x => x.Company.ContactUser).SetValidator(new UserValidator());
            RuleForEach(x => x.Company.Phones).SetValidator(new PhoneValidator());
        }
    }
}
