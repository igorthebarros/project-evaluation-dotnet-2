using Application.Commands.Orders.Create;
using Bogus;
using Domain.Entities;

namespace Unit.TestData
{
    public static class OrderTestData
    {
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
            .RuleFor(op => op.ProductId, f => ProductFaker.Generate().Id)
            .RuleFor(op => op.Quantity, f => f.Random.UInt(1, 50))
            .RuleFor(op => op.TotalAmount, 1);

        private static readonly Faker<Order> orderFake = new Faker<Order>()
            .RuleFor(c => c.CompanyId, f => CompanyTestData.GenerateValidCompany().Id)
            .RuleFor(c => c.AddressId, f => AddressTestData.GenerateValidAddress().Id)
            .RuleFor(c => c.UserId, f => UserTestData.GenerateValidUser().Id)
            .RuleFor(c => c.OrderProducts, f => OrderProductFaker.Generate(f.Random.Int(1, 5)))
            .RuleFor(c => c.Id, f => f.Random.Guid())
            .RuleFor(o => o.CreatedAt, f => f.Date.Past())
            .RuleFor(o => o.UpdatedAt, f => f.Date.Recent());

        private static readonly Faker<CreateOrderCommand> createOrderCommandFake = new Faker<CreateOrderCommand>()
            .RuleFor(c => c.CompanyId, f => CompanyTestData.GenerateValidCompany().Id)
            .RuleFor(c => c.AddressId, f => AddressTestData.GenerateValidAddress().Id)
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
