using Koperasi_Tentera_API.Models;
using Koperasi_Tentera_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koperasi_Tentera_API.Controllers
{
    // Controllers
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // API to validate IC Number
        [HttpPost("validate")]
        public async Task<IActionResult> ValidateCustomerAsync([FromBody] string icNumber)
        {
            // Validate customer fields (IC Number, Email, Mobile)
            string validationResult = await _customerService.ValidateCustomerICNumberAsync(icNumber);
            if(validationResult.Contains("exist"))
            {
                return BadRequest(validationResult);
            }

            return Ok(new { message = validationResult }); // Return vaidation message
        }

        //API to Add/login customer and validate 
        [HttpPost("register-or-validate")]
        public async Task<IActionResult> RegisterOrValidate([FromBody] Customer customer)
        {
            var result = await _customerService.RegisterOrValidateCustomerAsync(customer);

            if(result.Contains("exists")) 
                return BadRequest(result);

            return Ok(new { Message = result });

        }

        [HttpPost("update-customer")]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] Customer customer)
        {
            string result = await _customerService.UpdateCustomerAsync(customer);

            if(result.Contains("customer"))
                 return BadRequest(result);

            return Ok(new { Message = result });
        }
    }
}
