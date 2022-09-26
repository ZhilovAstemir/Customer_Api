using EFRepository.Entities;
using EFRepository.Repositories;
using Xunit;

namespace EFRerpository.tests.Repositories
{
    public class AddressRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var addressRepository = new AddressRepository();

            Assert.NotNull(addressRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var addressRepository = new AddressRepository();
            var addressFixture = MockAddress();

            addressRepository.Create(addressFixture);
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var addressRepository = new AddressRepository();
            var addressFixture = MockAddress();

            var address = addressRepository.Read(1);

            Assert.Equal(address.AddressLine, addressFixture.AddressLine);
            Assert.Equal(address.AddressLine2, addressFixture.AddressLine2);
            Assert.Equal(address.City, addressFixture.City);
            Assert.Equal(address.PostalCode, addressFixture.PostalCode);
            Assert.Equal(address.Country, addressFixture.Country);
            Assert.Equal(address.State, addressFixture.State);
            Assert.Equal(address.AddressType, addressFixture.AddressType);
            Assert.Equal(address.CustomerId, addressFixture.CustomerId);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var addressRepository = new AddressRepository();
            var addressFixtureUpdate = MockAddressUpdate();

            addressRepository.Update(addressFixtureUpdate);

            var address = addressRepository.Read(1);

            Assert.Equal(address.AddressLine, addressFixtureUpdate.AddressLine);
            Assert.Equal(address.AddressLine2, addressFixtureUpdate.AddressLine2);
            Assert.Equal(address.City, addressFixtureUpdate.City);
            Assert.Equal(address.PostalCode, addressFixtureUpdate.PostalCode);
            Assert.Equal(address.Country, addressFixtureUpdate.Country);
            Assert.Equal(address.State, addressFixtureUpdate.State);
            Assert.Equal(address.AddressType, addressFixtureUpdate.AddressType);
            Assert.Equal(address.CustomerId, addressFixtureUpdate.CustomerId);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressRepository = new AddressRepository();

            addressRepository.Delete(1);

            var address = addressRepository.Read(1);

            Assert.Null(address);
        }

        [Fact]
        public void ShouldBeAbleToGetAllAddress()
        {
            var addressRepository = new AddressRepository();

            var addresses = addressRepository.GetAll(2);

            Assert.Equal(2, addresses.Count);
        }

        public Address MockAddress()
        {
            var address = new Address
            {
                AddressLine = "AddressLine",
                AddressLine2 = "AddressLine2",
                City = "City",
                PostalCode = "123456",
                Country = "USA",
                State = "State",
                AddressType = "Shipping",
                CustomerId = 2
            };
            return address;
        }

        public Address MockAddressUpdate()
        {
            var address = new Address
            {
                AddressId = 1,
                AddressLine = "Address",
                AddressLine2 = "Address2",
                City = "Cit",
                PostalCode = "123451",
                Country = "USA",
                State = "Stat",
                AddressType = "Shipping",
                CustomerId = 2
            };
            return address;
        }
    }
}
