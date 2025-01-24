using Koperasi_Tentera_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace Koperasi_Tentera_API
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OTP> OTPs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    }
}
