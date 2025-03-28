using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using ReviewApplication.Domain;

namespace ReviewApplication.Application
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }

        public async  Task<Result<List<Customer>>> GetCustomers()
        {

            try
            {
                var data =  await _customerRepository.Get();
                Result<List<Customer>> result = new Result<List<Customer>>();
                if (data != null)
                {
                    var customersList = data.ToList();
                    result.Success = true;
                    result.Data = customersList;
                    result.Message = "Success";

                }
                else
                {

                    result.Message = "Not found";
                }

                return result;

            }
            catch (Exception e)
            {
                Result<List<Customer>> result = new Result<List<Customer>>();
                result.Message = e.Message;

                return result;
            }

        }


        public async Task<Result<Customer>> SaveCustomer(Customer customer)
        {

            try
            {
                Result<Customer> result = new Result<Customer>();

                Customer newCustomer = new Customer()
                {


                    Id = customer.Id,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    Email = customer.Email

                };



                var data = await _customerRepository.Save(customer);

                if (data != null)
                {
                    result.Success = true;
                    result.Data = data;
                    result.Message = "customer saved";

                }
                else
                {

                    result.Message = "Error";
                }

                return result;

            }
            catch (Exception e)
            {
                Result<Customer> result = new Result<Customer>();
                result.Message = e.Message;

                return result;
            }

        }

    }
}
