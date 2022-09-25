using Microsoft.AspNetCore.Mvc;
using EFRepository.Repositories;
using EFRepository.Entities;
using EFRepository.Interfaces;

namespace Customer_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private IRepository<Customer> customerRepository;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
            customerRepository = new CustomerRepository();
        }

        [HttpGet("AllCustomer")]
        
        public IEnumerable<Customer> GetAllCustomer()
        {
            return customerRepository.GetAll(1);
        }

        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            var customer = customerRepository.Read(id);

            return customer;
        }

        [HttpPost("Create")]
        public void CreateCustomer(Customer customer)
        {
            customerRepository.Create(customer);
        }

        [HttpPost("Update")]
        public void UpdateCustomer(Customer customer)
        {
            customerRepository.Update(customer);
        }

        [HttpDelete("Delete/{id}")]
        public void DeleteCustomer(int id)
        {
            customerRepository.Delete(id);
        }
    }
}