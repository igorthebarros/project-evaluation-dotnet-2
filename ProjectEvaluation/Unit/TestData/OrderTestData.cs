using Application.Commands.Orders.Create;
using Bogus;
using Domain.Entities;

namespace Unit.TestData
{
    public static class OrderTestData
    {
        private static Faker<Address> AddressFaker => new Faker<Address>()
            .RuleFor(a => a.Id, f => f.Random.Guid())
            .RuleFor(a => a.CreatedAt, f => f.Date.Past())
            .RuleFor(a => a.UpdatedAt, f => f.Date.Recent())
            .RuleFor(a => a.StreetName, f => f.Address.StreetName())
            .RuleFor(a => a.Number, f => f.Random.UInt(1, 9999))
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.Neighborhood, f => f.Address.County())
            .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

        private static Faker<Product> ProductFaker => new Faker<Product>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.CreatedAt, f => f.Date.Past())
            .RuleFor(p => p.UpdatedAt, f => f.Date.Recent())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.IsAvailable, f => f.Random.Bool())
            .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000));

        private static Faker<OrderProduct> OrderProductFaker => new Faker<OrderProduct>()
            .RuleFor(op => op.Id, f => f.Random.Guid())
            .RuleFor(op => op.CreatedAt, f => f.Date.Past())
            .RuleFor(op => op.UpdatedAt, f => f.Date.Recent())
            .RuleFor(op => op.OrderId, f => f.Random.Guid())
            .RuleFor(op => op.Product, f => ProductFaker.Generate())
            .RuleFor(op => op.Quantity, f => f.Random.UInt(1, 50))
            .RuleFor(op => op.TotalAmount, (f, op) => op.Product.Price * op.Quantity);

        private static Faker<User> UserFaker => new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Guid())
            .RuleFor(u => u.CreatedAt, f => f.Date.Past())
            .RuleFor(u => u.UpdatedAt, f => f.Date.Recent())
            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
            .RuleFor(u => u.LastName, f => f.Person.LastName)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Phone, f => "+55988888888")
            .RuleFor(u => u.Password, f => "S3cur3P4$$w0rD");

        private static Faker<Phone> PhoneFaker => new Faker<Phone>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.CreatedAt, f => f.Date.Past())
            .RuleFor(p => p.UpdatedAt, f => f.Date.Recent())
            .RuleFor(p => p.Number, f => "+55988888888");

        private static Faker<Company> CompanyFaker => new Faker<Company>()
            .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
            .RuleFor(c => c.TradeName, f => f.Company.CompanySuffix())
            .RuleFor(c => c.CNPJ, f => "04252011000110")
            .RuleFor(c => c.Adresses, f => AddressFaker.Generate(f.Random.Int(1, 3)))
            .RuleFor(c => c.Phones, f => PhoneFaker.Generate(f.Random.Int(1, 3)))
            .RuleFor(c => c.ContactUser, f => UserFaker.Generate(f.Random.Int(1, 3)));

        private static readonly Faker<Order> orderFake = new Faker<Order>()
            .RuleFor(c => c.Company, f => CompanyFaker.Generate())
            .RuleFor(c => c.Address, f => AddressFaker.Generate())
            .RuleFor(c => c.OrderProducts, f => OrderProductFaker.Generate(f.Random.Int(1, 5)))
            .RuleFor(c => c.Id, f => f.Random.Guid())
            .RuleFor(o => o.CreatedAt, f => f.Date.Past())
            .RuleFor(o => o.UpdatedAt, f => f.Date.Recent());

        private static readonly Faker<CreateOrderCommand> createOrderCommandFake = new Faker<CreateOrderCommand>()
            .RuleFor(c => c.Company, f => CompanyFaker.Generate())
            .RuleFor(c => c.Address, f => AddressFaker.Generate())
            .RuleFor(c => c.OrderProducts, f => OrderProductFaker.Generate(f.Random.Int(1, 5)))
            .RuleFor(c => c.Id, f => f.Random.Guid())
            .RuleFor(o => o.CreatedAt, f => f.Date.Past())
            .RuleFor(o => o.UpdatedAt, f => f.Date.Recent());

        public static CreateOrderCommand GenerateValidCommand()
        {
            return createOrderCommandFake.Generate();
        }

        public static Order GenerateValidOrder()
        {
            return orderFake.Generate();
        }
    }
}
