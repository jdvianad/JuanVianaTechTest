using Microsoft.VisualBasic;
using Moq;
using ReviewApplication.Application;
using ReviewApplication.Domain;

namespace ReviewApplication.Test
{
    public class SaveCustomer
    {
        private readonly Mock<ICustomerRepository> _fakeCustomerRepository = new();
        private CustomerService _customerService;

        [Fact]
        public async Task Save()
        {

            var newCustomer = new Customer()
            {
                Id = 1,
                Name = "Juan",
                Lastname="Duque",
                Email ="ElCorreo@gmail.com",
                 
            };

            _fakeCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>())).ReturnsAsync(newCustomer);
            _customerService = new CustomerService(_fakeCustomerRepository.Object);

            var data = await _customerService.SaveCustomer(newCustomer);
            Assert.True(data.Success);

        }

        public async Task SaveError()
        {

            var newCustomer = new Customer()
            {
                Id = 1,
                Name = "Juan",
                Lastname = "Duque",
                Email = "ElCorreo@gmail.com",

            };

            _fakeCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>())).Throws(new Exception("repository error"));
            _customerService = new CustomerService(_fakeCustomerRepository.Object);

            var data = await _customerService.SaveCustomer(newCustomer);

            Assert.False(data.Success);
            Assert.NotEmpty(data.Message);

        }
    }
}