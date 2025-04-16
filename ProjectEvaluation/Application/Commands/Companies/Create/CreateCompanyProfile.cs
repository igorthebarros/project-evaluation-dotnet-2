using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Companies.Create
{
    public class CreateCompanyProfile : Profile
    {
        public CreateCompanyProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<Company, CreateCompanyCommand>();
        }
    }
}
