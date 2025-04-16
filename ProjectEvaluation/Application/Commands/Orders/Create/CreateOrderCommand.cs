using Common.Validation;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Orders.Create
{
    /// <summary>
    /// Command for creating a new Order.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a Order. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateOrderResult"/>.
    /// The data provided in this command is validated using the 
    /// <see cref="CreateOrderValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
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
