using EFRepository.Entities;
using EFRepository.Interfaces;

namespace EFRepository.Repositories
{
    public class AddressRepository: IRepository<Address>
    {
        private readonly CustomerDbContext _context;

        public AddressRepository()
        {
            _context = new CustomerDbContext();
        }

        public void Create(Address entity)
        {
            _context
                .Addresses
                .Add(entity);
            _context
                .SaveChanges();
        }

        public void Delete(int entityCode)
        {
            var address = _context
                .Addresses
                .FirstOrDefault(c => c.AddressId == entityCode);

            _context
                .Addresses
                .Remove(address);

            _context.SaveChanges();
        }

        public List<Address> GetAll(int entityCode)
        {
            var addresses = _context
                .Addresses              
                .Where(a => a.CustomerId == entityCode)
                .ToList();

            return addresses;
        }

        public Address Read(int entityCode)
        {
            return _context
                       .Addresses
                       .FirstOrDefault(c => c.AddressId == entityCode);

        }

        public void Update(Address entity)
        {
            _context
                .Entry(entity)
                .State = System.Data.Entity.EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
