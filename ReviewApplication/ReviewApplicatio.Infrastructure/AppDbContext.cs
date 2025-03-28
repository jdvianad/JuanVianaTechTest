using Microsoft.EntityFrameworkCore;
using ReviewApplication.Domain;

namespace ReviewApplicatio.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {


        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }



    }
}
