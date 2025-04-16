using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Companies.Create
{
    /// <summary>
    /// Profile for mapping between Company entity and CreateCompanyCommand
    /// </summary>
    public class CreateCompanyProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateCompany operation
        /// </summary>
        public CreateCompanyProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<Company, CreateCompanyCommand>();
        }
    }
}
