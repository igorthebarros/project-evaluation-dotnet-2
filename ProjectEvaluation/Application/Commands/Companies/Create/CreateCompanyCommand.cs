using Common.Validation;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Companies.Create
{
    /// <summary>
    /// Command for creating a new Company.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a Company. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateCompanyResult"/>.
    /// The data provided in this command is validated using the 
    /// <see cref="CreateCompanyValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateCompanyCommand : Company, IRequest<CreateCompanyResult>
    {
        public ValidationResultDetail Validate()
        {
            var validator = new CreateCompanyCommand();
            var result = validator.Validate();
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(x => (ValidationErrorDetail)x)
            };
        }
    }
}
