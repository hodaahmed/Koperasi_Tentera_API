namespace Koperasi_Tentera_API.DTO
{
    public class OTPValidationRequest
    {
        public Guid CustomerId { get; set; }  // Changed from int to Guid
        public string OTP { get; set; }
        public string OTPType { get; set; } // Email or Mobile
    }
}
