namespace Koperasi_Tentera_API.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ICNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
    }
}
