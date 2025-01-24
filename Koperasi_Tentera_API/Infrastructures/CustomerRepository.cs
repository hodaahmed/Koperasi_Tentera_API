using Koperasi_Tentera_API.Infrastructures.Interfaces;
using Koperasi_Tentera_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Koperasi_Tentera_API.Infrastructures
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public async Task<Customer> GetByICNumberAsync(string icNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.ICNumber == icNumber);
        }

        public async Task<bool> IsEmailOrMobileExistAsync(string email, string mobile)
        {
            return await _dbSet.AnyAsync(c => c.Email == email || c.MobileNumber == mobile);
        }
        public async Task UpdateAsync(Customer customer)
        {
            // First, check if the customer exists
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);
            if (existingCustomer != null)
            {
                // Mark the entity as modified
                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Customer not found.");
            }
        }
    }
}
