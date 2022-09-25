using EFRepository.Entities;
using EFRepository.Interfaces;
using EFRepository.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private IRepository<Address> addressRepository;

        public AddressController()
        {
            addressRepository = new AddressRepository();
        }

        // GET: api/<AddressController>
        [HttpGet("all/{id}")]
        public IEnumerable<Address> GetAllAddress(int id)
        {
            return addressRepository.GetAll(id);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public Address Get(int id)
        {
            return addressRepository.Read(id);
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post(Address address)
        {
            addressRepository.Create(address);
        }

        // PUT api/<AddressController>/5
        [HttpPut]
        public void Put(Address address)
        {
            addressRepository.Update(address);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            addressRepository.Delete(id);
        }
    }
}
