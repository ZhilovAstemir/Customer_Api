using EFRepository.Entities;
using EFRepository.Interfaces;
using EFRepository.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private IRepository<Note> noteRepository;

        public NoteController()
        {
            noteRepository = new NoteRepository();
        }

        // GET: api/<NoteController>
        [HttpGet("all/{id}")]
        public IEnumerable<Note> GetAllNote(int id)
        {
            return noteRepository.GetAll(id);
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public Note Get(int id)
        {
            return noteRepository.Read(id);
        }

        // POST api/<NoteController>
        [HttpPost]
        public void Post(Note note)
        {
            noteRepository.Create(note);
        }

        // PUT api/<NoteController>/5
        [HttpPut]
        public void Put(Note note)
        {
            noteRepository.Update(note);
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            noteRepository.Delete(id);
        }
    }
}
