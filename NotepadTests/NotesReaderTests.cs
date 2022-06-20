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
            string path = Path.Combine(Environment.CurrentDirectory, notesReader.fileName);

            Note note1 = new Note() { Title = "title1", Description = "description1", Content = "content1" };
            Note note2 = new Note() { Title = "title2", Description = "description2", Content = "content2" };
            List<Note> notes = new List<Note>() { note1, note2 };  

            //act
            notesReader.SaveNotes(notes);

            //assert
            Assert.IsTrue(File.Exists(path));
            Assert.AreEqual(2, File.ReadAllLines(path).Length);

            File.Delete(path);
        }

        [TestMethod]
        public void LoadNotes_TextFileOnHardDriveIsGiven_ListOfNotesIsCreated()
        {
            //arrange
            NotesReader notesReader = new NotesReader();
            string path = Path.Combine(Environment.CurrentDirectory, notesReader.fileName);

            string title1 = "title1";
            string description1 = "description1";
            string content1 = "content1";
            string created1 = DateTime.Now.ToString();
            string modified1 = DateTime.Now.ToString();

            string content = $"Title:{title1}|Description:{description1}|Content:{content1}|Created:{created1}|Modified:{modified1}";

            File.WriteAllText(path, content);

            //act
            var notes = notesReader.LoadNotes();

            //assert
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(title1, notes[0].Title);

            File.Delete(path);
        }
    }
}