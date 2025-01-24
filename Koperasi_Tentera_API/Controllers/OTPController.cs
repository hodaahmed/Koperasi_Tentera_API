using Koperasi_Tentera_API.DTO;
using Koperasi_Tentera_API.Models;
using Koperasi_Tentera_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Koperasi_Tentera_API.Controllers
{
    // Controllers
    [ApiController]
    [Route("api/OTP")]
    public class OTPController : ControllerBase
    {
        private readonly IOTPService _otpService;

        public OTPController(IOTPService otpService)
        {
            _otpService = otpService;
        }

        // API to validate OTP
        [HttpPost("validate-otp")]
        public async Task<IActionResult> ValidateOTPAsync([FromBody] OTPValidationRequest request)
        {
            // Validate OTP
            string validationResult = await _otpService.ValidateOTPAsync(request.CustomerId, request.OTP, request.OTPType);

            if (validationResult == "OTP validated successfully.")
            {
                return Ok(new { message = validationResult });
            }

            return BadRequest(new { message = validationResult });
        }
    }
}
