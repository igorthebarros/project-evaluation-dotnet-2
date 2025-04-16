using Domain.Validation;
using FluentValidation;

namespace Application.Commands.Orders.Create
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator() { }
    }
}
