using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class NotesStorage
    {
        public List<Note> Notes { get; set; }

        public NotesStorage()
        {
            Notes = new List<Note>();
        }

        public void AddNote()
        {
            Console.Clear();
            Console.Write("Tytuł notatki: ");
            string title = Console.ReadLine();
            Console.Write("Opis notatki: ");
            string description = Console.ReadLine();
            Console.Write("Zawartość notatki: ");
            string content = Console.ReadLine();

            Note note = new Note(title, description, content);

            Notes.Add(note);

            Console.WriteLine("Dodano notatkę.");
            Console.ReadLine();
        }
    }
}
