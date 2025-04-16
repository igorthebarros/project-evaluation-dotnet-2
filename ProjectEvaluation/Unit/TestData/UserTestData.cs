using Bogus;
using Domain.Entities;

namespace Unit.TestData
{
    public class UserTestData
    {
        private static Faker<User> userFaker => new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Guid())
            .RuleFor(u => u.CreatedAt, f => f.Date.Past())
            .RuleFor(u => u.UpdatedAt, f => f.Date.Recent())
            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
            .RuleFor(u => u.LastName, f => f.Person.LastName)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Phone, f => "+55988888888")
            .RuleFor(u => u.Password, f => "S3cur3P4$$w0rD");

        public static User GenerateValidUser()
        {
            return userFaker.Generate();
        }
    }
}
