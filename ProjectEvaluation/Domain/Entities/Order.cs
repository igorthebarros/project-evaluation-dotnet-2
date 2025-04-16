namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; } = [];
    }
}
