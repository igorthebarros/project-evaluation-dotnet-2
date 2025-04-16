namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public string CNPJ { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string TradeName { get; set; } = string.Empty;
        public IEnumerable<Address> Adresses { get; set; } = Enumerable.Empty<Address>();
        public IEnumerable<Phone> Phones { get; set; } = Enumerable.Empty<Phone>();
        public IEnumerable<User> ContactUser { get; set; } = Enumerable.Empty<User>();

    }
}
