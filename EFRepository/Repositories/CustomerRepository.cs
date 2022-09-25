using EFRepository.Entities;
using EFRepository.Interfaces;

namespace EFRepository.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {

        private readonly CustomerDbContext _context;

        public CustomerRepository()
        {
            _context = new CustomerDbContext();
        }

        public void Create(Customer entity)
        {
            _context
                .Customer
                .Add(entity);
            _context
                .SaveChanges();
        }

        public void Delete(int entityCode)
        {
            var customer = _context
                .Customer
                .FirstOrDefault(c => c.CustomerId == entityCode);

            _context
                .Customer
                .Remove(customer);

            _context.SaveChanges();
        }

        public List<Customer> GetAll(int entityCode)
        {
            var customers = _context.Customer.ToList();

            return customers;
        }

        public Customer Read(int entityCode)
        {
            return _context
                       .Customer
                       .FirstOrDefault(c => c.CustomerId == entityCode);

        }

        public void Update(Customer entity)
        {
            _context
                .Entry(entity)
                .State = System.Data.Entity.EntityState.Modified;

            _context.SaveChanges();                
        }
    }
}
