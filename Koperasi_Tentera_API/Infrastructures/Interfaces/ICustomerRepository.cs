using Koperasi_Tentera_API.Models;

namespace Koperasi_Tentera_API.Infrastructures.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByICNumberAsync(string icNumber);
        Task<bool> IsEmailOrMobileExistAsync(string email, string mobile);
        Task UpdateAsync(Customer customer);
    }
}
