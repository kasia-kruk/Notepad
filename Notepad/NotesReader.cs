using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class NotesReader
    {
        public string fileName = "Notes.txt";

        public void SaveNotes(List<Note> notes)
        {
            string textFileContent = ConvertNotesToString(notes);

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, fileName), textFileContent);
        }

        private string ConvertNotesToString(List<Note> notes)
        {
            string textFileContent = "";

            foreach (var note in notes)
            {
                if (textFileContent == "")
                {
                    textFileContent += $"Title:{note.Title}|Description:{note.Description}|Content:{note.Content}|Created:{note.Created}|Modified:{note.Modified}";
                }
                else
                {
                    textFileContent += $"\nTitle:{note.Title}|Description:{note.Description}|Content:{note.Content}|Created:{note.Created}|Modified:{note.Modified}";
                }
            }
            return textFileContent;
        }

        public List<Note> LoadNotes()
        {
            List<Note> notes = new List<Note>();

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, fileName)))
            {
                var textFileContent = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, fileName)).ToList();

                foreach (var line in textFileContent)
                {
                    var noteProperties = line.Split('|');

                    if (noteProperties.Length != 5)
                    {
                        continue;
                    }

                    var noteTitle = noteProperties[0].Substring(noteProperties[0].IndexOf(':') + 1);
                    var noteDescription = noteProperties[1].Substring(noteProperties[1].IndexOf(':') + 1);
                    var noteContent = noteProperties[2].Substring(noteProperties[2].IndexOf(':') + 1);
                    var noteCreationDate = noteProperties[3].Substring(noteProperties[3].IndexOf(':') + 1);
                    var noteModificationDate = noteProperties[4].Substring(noteProperties[4].IndexOf(':') + 1);

                    Note note = new Note(noteTitle, noteDescription, noteContent, noteCreationDate, noteModificationDate);

                    notes.Add(note);
                }
            }

            return notes;
        }
    }
}