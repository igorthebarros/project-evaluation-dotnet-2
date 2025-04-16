using Application.Commands.Companies.Create;
using Bogus;
using Domain.Entities;

namespace Unit.TestData
{
    public static class CompanyTestData
    {
        private static Faker<Company> companyFaker => new Faker<Company>()
            .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
            .RuleFor(c => c.TradeName, f => f.Company.CompanySuffix())
            .RuleFor(c => c.CNPJ, f => "04252011000110")
            .RuleFor(c => c.Adresses, f => new List<Address> { AddressTestData.GenerateValidAddress() })
            .RuleFor(c => c.Phones, f => new List<Phone> { PhoneTestData.GenerateValidPhone() })
            .RuleFor(c => c.ContactUser, f => new List<User> { UserTestData.GenerateValidUser() });

        private static Faker<CreateCompanyCommand> createCompanyCommand => new Faker<CreateCompanyCommand>()
            .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
            .RuleFor(c => c.TradeName, f => f.Company.CompanySuffix())
            .RuleFor(c => c.CNPJ, f => "04252011000110")
            .RuleFor(c => c.Adresses, f => new List<Address> { AddressTestData.GenerateValidAddress() })
            .RuleFor(c => c.Phones, f => new List<Phone> { PhoneTestData.GenerateValidPhone() })
            .RuleFor(c => c.ContactUser, f => new List<User> { UserTestData.GenerateValidUser() });

        public static CreateCompanyCommand GenerateValidCommand()
        {
            return createCompanyCommand.Generate();
        }

        public static Company GenerateValidCompany()
        {
            return companyFaker.Generate();
        }
    }
}
