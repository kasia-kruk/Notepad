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

        public void DeleteNote()
        {
            ConsoleKeyInfo key;
            int selectedMenuIndex = 0;
            do
            {
                Console.Clear();
                Display(selectedMenuIndex);
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (selectedMenuIndex == Notes.Count - 1)
                    {
                        selectedMenuIndex = 0;
                    }
                    else
                    {
                        selectedMenuIndex++;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (selectedMenuIndex == 0)
                    {
                        selectedMenuIndex = Notes.Count - 1;
                    }
                    else
                    {
                        selectedMenuIndex--;
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    var noteToBeDeleted = Notes[selectedMenuIndex];
                    Notes.Remove(noteToBeDeleted);
                    break;
                case ConsoleKey.Escape:

                    break;
                default:
                    break;
            }
        }

        private void Display(int selectedMenuIndex)
        {
            for (int i = 0; i < Notes.Count; i++)
            {
                if (i == selectedMenuIndex)
                {
                    Console.WriteLine($">> {Notes[i].Title} <<");
                }
                else
                {
                    Console.WriteLine(Notes[i].Title);
                }
            }
        }

        public void DisplayAllNotes()
        {
            Console.Clear();
            foreach (var note in Notes)
            {
                Console.WriteLine($"\nTitle:{note.Title}|Description:{note.Description}|Content:{note.Content}|Created:{note.Created}|Modified:{note.Modified}");
                Console.ReadLine();
            }
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
