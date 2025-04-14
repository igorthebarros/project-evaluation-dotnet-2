namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string StreetName { get; set; } = string.Empty;
        public uint Number {  get; set; }
        public string City { get; set; } = string.Empty;
        public string Neighborhood {  get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
