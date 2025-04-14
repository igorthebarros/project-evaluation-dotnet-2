namespace Domain.Entities
{
    public class OrderProduct : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Product Product { get; set; } = new Product();
        public uint Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
