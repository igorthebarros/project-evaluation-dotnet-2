using Common.Validation;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Companies.Create
{
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
