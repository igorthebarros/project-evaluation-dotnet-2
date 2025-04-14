namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Company Company { get; set; } = new Company();
        public IEnumerable<OrderProduct> OrderProducts { get; set; } = Enumerable.Empty<OrderProduct>();
        public Address Address { get; set; } = new Address();
    }
}
