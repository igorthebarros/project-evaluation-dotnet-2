using Bogus;
using Domain.Entities;

namespace Unit.TestData
{
    public static class PhoneTestData
    {
        private static Faker<Phone> phoneFaker => new Faker<Phone>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.CreatedAt, f => f.Date.Past())
            .RuleFor(p => p.UpdatedAt, f => f.Date.Recent())
            .RuleFor(p => p.Number, f => "+55988888888");

        public static Phone GenerateValidPhone()
        {
            return phoneFaker.Generate();
        }
    }
}
