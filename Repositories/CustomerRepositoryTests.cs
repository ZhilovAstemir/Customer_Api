using EFRepository.Entities;
using EFRepository.Repositories;
using Xunit;

namespace EFRerpository.tests.Repositories
{
    
    public class CustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var customerRepository = new CustomerRepository();

            Assert.NotNull(customerRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customerFixture = MockCustomer();

            customerRepository.Create(customerFixture);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customerFixture = MockCustomer();

            var customer = customerRepository.Read(1);

            Assert.Equal(customerFixture.FirstName, customer.FirstName);
            Assert.Equal(customerFixture.LastName, customer.LastName);
            Assert.Equal(customerFixture.PhoneNumber, customer.PhoneNumber);
            Assert.Equal(customerFixture.Email, customer.Email);
            Assert.Equal(customerFixture.TotalPurchasesAmount, customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customerFixtureUpdate = MockCustomerUpdate();

            customerRepository.Update(customerFixtureUpdate);

            var customer = customerRepository.Read(1);

            Assert.Equal(customerFixtureUpdate.FirstName, customer.FirstName);
            Assert.Equal(customerFixtureUpdate.LastName, customer.LastName);
            Assert.Equal(customerFixtureUpdate.PhoneNumber, customer.PhoneNumber);
            Assert.Equal(customerFixtureUpdate.Email, customer.Email);
            Assert.Equal(customerFixtureUpdate.TotalPurchasesAmount, customer.TotalPurchasesAmount);
        }   

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new CustomerRepository();

            customerRepository.Delete(1);

            var customer = customerRepository.Read(1);

            Assert.Null(customer);
        }

        [Fact]
        public void ShouldBeAbleToGetAllCustomers()
        {
            var customerRepository = new CustomerRepository();

            var customers = customerRepository.GetAll(1);

            Assert.Equal(2, customers.Count);
        }

        public Customer MockCustomer()
        {
            var customer = new Customer{
                FirstName = "Tom",
                LastName = "Hengs",
                PhoneNumber = "+12345678901",
                Email = "email@mail.com",
                TotalPurchasesAmount = 5
            };
            return customer;
        }

        public Customer MockCustomerUpdate()
        {
            var customer = new Customer
            {
                CustomerId= 1,
                FirstName = "Jeff",
                LastName = "Besos",
                PhoneNumber = "+12345672901",
                Email = "el@mail.com",
                TotalPurchasesAmount = 4
            };
            return customer;
        }
    }
}
