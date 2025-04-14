using Common.Validation;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Orders.Create
{
    public class CreateOrderCommand : Order, IRequest<CreateOrderResult>
    {
        public ValidationResultDetail Validate()
        {
            var validator = new CreateOrderValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
