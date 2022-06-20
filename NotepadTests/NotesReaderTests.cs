using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notepad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadTests
{
    [TestClass]
    public class NotesReaderTests
    {
        [TestMethod]
        public void SaveNotes_ListOfNotesIsGiven_TextFileIsCreated()
        {
            //arrange
            NotesReader notesReader = new NotesReader();

            Note note1 = new Note() { Title = "title1", Description = "description1", Content = "content1" };
            Note note2 = new Note() { Title = "title2", Description = "description2", Content = "content2" };
            List<Note> notes = new List<Note>() { note1, note2 };  

            //act
            notesReader.SaveNotes(notes);

            //assert
            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, notesReader.fileName)));
            Assert.AreEqual(2, File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, notesReader.fileName)).Length);

            File.Delete(Path.Combine(Environment.CurrentDirectory, notesReader.fileName));
        }
    }
}