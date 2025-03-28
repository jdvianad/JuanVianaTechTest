using Microsoft.EntityFrameworkCore;
using ReviewApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplicatio.Infrastructure
{
     public class CustomerRepository: ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;

        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> Save(Customer customer)
        {
            var result = await _appDbContext.Customers.AddAsync(customer);
            await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

    }

}
