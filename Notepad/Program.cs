using System;
using System.Collections.Generic;

namespace Notepad
{
    public class Program
    {
        private static NotesReader _notesReader;
        private static List<Note> _notes;

        public static void Main(string[] args)
        {
            LoadNotes();

            ConsoleKeyInfo key;
            Menu menu = new Menu();

            do
            {
                menu.Display();
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (menu.SelectedMenuIndex == menu.MenuOptions.Count - 1)
                    {
                        menu.SelectedMenuIndex = 0;
                    }
                    else
                    {
                        menu.SelectedMenuIndex++;
                    }                   
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (menu.SelectedMenuIndex == 0)
                    {
                        menu.SelectedMenuIndex = menu.MenuOptions.Count - 1;
                    }
                    else
                    {
                        menu.SelectedMenuIndex--;
                    }
                }
            } 
            while (key.Key != ConsoleKey.Enter);

            switch (menu.SelectedMenuIndex)
            {
                case 0:
                    //TODO: Wywołać metodę do wyświetlenia notatek.
                    break;
                case 1:
                    //TODO : Dodać metodę do tworzenia nowej notatki.
                    break;
                case 2:
                    //TODO: Dodać metodę do usuwania wybranej notatki.
                    break;
                case 3:
                    break;
                case 4:
                    CloseNotepad();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private static void LoadNotes()
        {
            //TODO: Kasia wywołuje ładowanie notatek.
            _notes = new List<Note>();
            _notesReader = new NotesReader();
        }

        private static void CloseNotepad()
        {
            _notesReader.SaveNotes(_notes);
            Environment.Exit(0);
        }
    }
}