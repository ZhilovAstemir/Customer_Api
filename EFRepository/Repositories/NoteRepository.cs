using EFRepository.Entities;
using EFRepository.Interfaces;

namespace EFRepository.Repositories
{
    public class NoteRepository: IRepository<Note>
    {
        private readonly CustomerDbContext _context;

        public NoteRepository()
        {
            _context = new CustomerDbContext();
        }

        public void Create(Note entity)
        {
            _context
                .Notes
                .Add(entity);
            _context
                .SaveChanges();
        }

        public void Delete(int entityCode)
        {
            var note = _context
                .Notes
                .FirstOrDefault(c => c.NoteId == entityCode);

            _context
                .Notes
                .Remove(note);

            _context.SaveChanges();
        }

        public List<Note> GetAll(int entityCode)
        {
            var notes = _context
                .Notes
                .Where(a => a.CustomerId == entityCode)
                .ToList();

            return notes;
        }

        public Note Read(int entityCode)
        {
            return _context
                       .Notes
                       .FirstOrDefault(c => c.NoteId == entityCode);

        }

        public void Update(Note entity)
        {
            _context
                .Entry(entity)
                .State = System.Data.Entity.EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
