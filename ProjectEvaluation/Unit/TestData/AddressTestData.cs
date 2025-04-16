using Bogus;
using Domain.Entities;

namespace Unit.TestData
{
    public static class AddressTestData
    {
        private static Faker<Address> addressFaker => new Faker<Address>()
            .RuleFor(a => a.Id, f => f.Random.Guid())
            .RuleFor(a => a.CreatedAt, f => f.Date.Past())
            .RuleFor(a => a.UpdatedAt, f => f.Date.Recent())
            .RuleFor(a => a.StreetName, f => f.Address.StreetName())
            .RuleFor(a => a.Number, f => f.Random.UInt(1, 9999))
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.Neighborhood, f => f.Address.County())
            .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

        public static Address GenerateValidAddress()
        {
            return addressFaker.Generate();
        }
    }
}
