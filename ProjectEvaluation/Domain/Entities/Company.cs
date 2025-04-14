namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public uint CNPJ { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string TradeName { get; set; } = string.Empty;
        public IEnumerable<Address> Adresses { get; set; } = Enumerable.Empty<Address>();
        public IEnumerable<Phone> Phones { get; set; } = Enumerable.Empty<Phone>();
        public IEnumerable<User> ContactUser { get; set; } = Enumerable.Empty<User>();

    }
}
