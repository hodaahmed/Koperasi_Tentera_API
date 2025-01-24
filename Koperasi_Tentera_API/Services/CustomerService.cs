using Koperasi_Tentera_API.Infrastructures.Interfaces;
using Koperasi_Tentera_API.Models;
using Koperasi_Tentera_API.Services.Interfaces;

namespace Koperasi_Tentera_API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOTPRepository _otpRepository;

        public CustomerService(ICustomerRepository customerRepository, IOTPRepository otpRepository)
        {
            _customerRepository = customerRepository;
            _otpRepository = otpRepository;
        }
        // Function to validate the customer's IC number
        public async Task<string> ValidateCustomerICNumberAsync(string icNumber)
        {
            // Check if the IC Number already exists in the repository
            var existingCustomer = await _customerRepository.GetByICNumberAsync(icNumber);

            if (existingCustomer != null)
            {
                // If the IC number exists, generate and send OTP
                return await GenerateAndSaveOTP(existingCustomer);
            }

            // If the IC number doesn't exist, return a message indicating this.
            return "IC Number is not exist before";
        }

        // Function to register a new customer or validate an existing one
        public async Task<string> RegisterOrValidateCustomerAsync(Customer customer)
        {
            // Check if either the email or mobile number already exists in the system.
            if (await _customerRepository.IsEmailOrMobileExistAsync(customer.Email, customer.MobileNumber))
            {
                // If either email or mobile number already exists, return an appropriate message
                return "Mobile or Email already exists.";
            }

            // If both are unique, add the new customer to the repository.
            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();

            // After adding the customer, generate and send OTP for both email and mobile.
            return await GenerateAndSaveOTP(customer);
        }

        // Function to update the customer details
        public async Task<string> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                // Attempt to update the customer data in the repository
                await _customerRepository.UpdateAsync(customer);
                await _customerRepository.SaveChangesAsync();

                // Return success message after the update
                return "updated successfully";
            }
            catch (Exception ex)
            {
                // If there is any error (e.g., customer not found), return a failure message
                return "Customer not found";
            }
        }

        // Private helper function to generate and save OTPs for both email and mobile
        private async Task<string> GenerateAndSaveOTP(Customer customer)
        {
            // Generate OTP for email and mobile separately
            var emailOtp = await CreateAndSaveOTP(customer, "Email");
            var mobileOtp = await CreateAndSaveOTP(customer, "Mobile");

            // Optionally, simulate sending OTPs (could be replaced by actual email or SMS sending logic)
            Console.WriteLine($"OTP for {customer.MobileNumber} (Mobile): {mobileOtp}");
            Console.WriteLine($"OTP for {customer.Email} (Email): {emailOtp}");

            // Return success message indicating OTPs have been sent
            return "OTP sent successfully , customerId : "+customer.Id+" ,mobile otp: "+mobileOtp +" , email otp: " + mobileOtp;
        }

        // Private helper function to create and save an OTP for a specific type (Email or Mobile)
        private async Task<string> CreateAndSaveOTP(Customer customer, string type)
        {
            // Check if there is already a valid OTP for the given customer and type (Email or Mobile)
            var validOtp = await _otpRepository.GetOTPAsync(customer.Id, type);

            if (validOtp != null)
            {
                // If a valid OTP exists, return the existing OTP code
                return validOtp.Code;
            }

            // Generate a new 6-digit OTP if no valid OTP exists
            var otpCode = new Random().Next(100000, 999999).ToString();

            // Create a new OTP object to store in the database
            var otp = new OTP
            {
                Code = otpCode, // Set the generated OTP code
                Expiry = DateTime.UtcNow.AddMinutes(2), // Set the OTP expiry time (2 minutes from now)
                CustomerId = customer.Id, // Associate OTP with the customer's ID
                Type = type // Specify whether it's for Email or Mobile
            };

            // Save the OTP to the OTP repository
            await _otpRepository.AddAsync(otp);
            await _otpRepository.SaveChangesAsync();

            // Return the generated OTP code
            return otpCode;
        }

    }

}
