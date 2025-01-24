namespace Koperasi_Tentera_API.Services.Interfaces
{
    public interface IOTPService
    {
        Task<string> ValidateOTPAsync(Guid customerId, string otpCode, string otpType);
    }
}
