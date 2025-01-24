namespace Koperasi_Tentera_API.Models
{
    public class OTP
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
        public string Type { get; set; } = string.Empty; // "Email" or "Mobile"

        //navigation property
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
