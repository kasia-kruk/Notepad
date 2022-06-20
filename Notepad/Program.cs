using System;

namespace Notepad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoadNotes();
            DisplayMenu();

            Console.ReadLine();
        }

        private static void LoadNotes()
        {
            NotesReader notesReader = new NotesReader();

        }

        private static void DisplayMenu()
        {
            Menu menu = new Menu();
            menu.Display();
        }
    }
}