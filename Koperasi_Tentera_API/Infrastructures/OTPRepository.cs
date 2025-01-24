using Koperasi_Tentera_API.Infrastructures.Interfaces;
using Koperasi_Tentera_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Koperasi_Tentera_API.Infrastructures
{
    public class OTPRepository : Repository<OTP>, IOTPRepository
    {
        public OTPRepository(AppDbContext context) : base(context) { }

        public async Task<OTP> GetOTPAsync(Guid customerId, string otpType)
        {
            return await _context.OTPs
                                 .FirstOrDefaultAsync(o => o.CustomerId == customerId && o.Type == otpType);
        }

        public async Task AddOTPAsync(OTP otp)
        {
            await _context.OTPs.AddAsync(otp);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
