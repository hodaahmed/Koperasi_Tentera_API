using Koperasi_Tentera_API.Models;

namespace Koperasi_Tentera_API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<string> ValidateCustomerICNumberAsync(string icNumber);
        Task<string> RegisterOrValidateCustomerAsync(Customer customer);
        Task<string> UpdateCustomerAsync(Customer customer);
    }

}
