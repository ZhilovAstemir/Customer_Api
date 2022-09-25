using EFRepository.Entities;
using System.Data.Entity;

namespace EFRepository.Repositories
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext()
            : base("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CustomerLib_Bekov;Integrated Security=True")
        {}

        public IDbSet<Customer> Customer { get; set; }
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Note> Notes { get; set; }
    }
}
