using Koperasi_Tentera_API.Infrastructures.Interfaces;
using Koperasi_Tentera_API.Services.Interfaces;

namespace Koperasi_Tentera_API.Services
{
    public class OTPService: IOTPService
    {
        private readonly IOTPRepository _otpRepository;

        public OTPService(IOTPRepository otpRepository)
        {
            _otpRepository = otpRepository;
        }
        // Validate OTP
        public async Task<string> ValidateOTPAsync(Guid customerId, string otpCode, string otpType)
        {
            // Get the OTP from the repository based on customer ID and OTP type (Email/Mobile)
            var storedOtp = await _otpRepository.GetOTPAsync(customerId, otpType);

            // Check if OTP exists
            if (storedOtp == null)
            {
                return "OTP not found.";
            }

            // Check if OTP has expired
            if (storedOtp.Expiry < DateTime.UtcNow)
            {
                return "OTP has expired.";
            }

            // Validate OTP code
            if (storedOtp.Code != otpCode)
            {
                return "Invalid OTP.";
            }

            // OTP is valid
            return "OTP validated successfully.";
        }

    }
}
