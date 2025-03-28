using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Domain
{
   public interface ICustomerRepository
    {
        Task<Customer> Save(Customer customer);
        Task<IEnumerable<Customer>> Get();


    }
}
