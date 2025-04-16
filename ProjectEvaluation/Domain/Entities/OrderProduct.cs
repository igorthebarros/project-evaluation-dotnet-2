namespace Domain.Entities
{
    public class OrderProduct : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
