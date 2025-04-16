using AutoMapper;
using Domain.Contracts.Services;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Commands.Companies.Create
{
    /// <summary>
    /// Handler for processing CreateCompanyCommand requests
    /// </summary>
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyResult>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _service;

        /// <summary>
        /// Initializes a new instance of CreateCompanyHandler
        /// </summary>
        /// <param name="service">The Company service</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateCompanyHandler(IMapper mapper, ICompanyService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Handles the CreateCompanyCommand request
        /// </summary>
        /// <param name="command">The CreateCompany command</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The created Company details</returns>
        public async Task<CreateCompanyResult> Handle(CreateCompanyCommand command, CancellationToken token)
        {
            var validator = new CreateCompanyValidator();
            var validationResult = await validator.ValidateAsync(command, token);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var company = _mapper.Map<Company>(command);

            var createdCompany = await _service.CreateAsync(company, token);
            var result = _mapper.Map<CreateCompanyResult>(createdCompany);
            return result;
        }
    }
}
