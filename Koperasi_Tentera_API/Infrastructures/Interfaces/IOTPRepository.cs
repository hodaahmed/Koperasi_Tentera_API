using Koperasi_Tentera_API.Models;

namespace Koperasi_Tentera_API.Infrastructures.Interfaces
{
    public interface IOTPRepository : IRepository<OTP>
    {
        Task<OTP> GetOTPAsync(Guid customerId, string otpType);
        Task AddOTPAsync(OTP otp);
        Task SaveChangesAsync();
    }
}
