using EFRepository.Entities;
using EFRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EFRerpository.tests.Repositories
{
    public class NoteRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateNoteRepository()
        {
            var noteRepository = new NoteRepository();

            Assert.NotNull(noteRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            var noteRepository = new NoteRepository();
            var noteFixture = MockNote();

            noteRepository.Create(noteFixture);
        }

        [Fact]
        public void ShouldBeAbleToReadNote()
        {
            var noteRepository = new NoteRepository();
            var noteFixture = MockNote();

            var note = noteRepository.Read(1);

            Assert.Equal(note.Notes, noteFixture.Notes);
            Assert.Equal(note.CustomerId, noteFixture.CustomerId);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNote()
        {
            var noteRepository = new NoteRepository();
            var noteFixtureUpdate = MockNoteUpdate();

            noteRepository.Update(noteFixtureUpdate);

            var note = noteRepository.Read(1);

            Assert.Equal(note.Notes, noteFixtureUpdate.Notes);
            Assert.Equal(note.CustomerId, noteFixtureUpdate.CustomerId);
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            var noteRepository = new NoteRepository();

            noteRepository.Delete(1);

            var notes = noteRepository.Read(1);

            Assert.Null(notes);
        }

        [Fact]
        public void ShouldBeAbleToGetAllNote()
        {
            var noteRepository = new NoteRepository();

            var notes = noteRepository.GetAll(2);

            Assert.Equal(2, notes.Count);
        }

        public Note MockNote()
        {
            var note = new Note
            {
                Notes = "aaa",
                CustomerId = 2
            };
            return note;
        }

        public Note MockNoteUpdate()
        {
            var note = new Note
            {
                NoteId = 1,
                Notes = "fff",
                CustomerId = 2
            };
            return note;
        }
    }
}
