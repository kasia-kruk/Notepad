using System;
using System.Collections.Generic;

namespace Notepad
{
    public class Program
    {
        private static NotesReader _notesReader;
        private static NotesStorage _notesStorage;

        public static void Main(string[] args)
        {
            LoadNotes();
            ConsoleKeyInfo key;
            Menu menu = new Menu();

            while (true)
            {
                DisplayMenu(menu);

                switch (menu.SelectedMenuIndex)
                {
                    case 0:
                        DisplayAllNotes();
                        break;
                    case 1:
                        AddNote();
                        break;
                    case 2:
                        _notesStorage.DeleteNote();
                        break;
                    case 3:
                        break;
                    case 4:
                        CloseNotepad();
                        break;
                    default:
                        break;
                }
            }       
        }

        private static void DisplayAllNotes()
        {
            _notesStorage.DisplayAllNotes();
        }

        private static void DisplayMenu(Menu menu)
        {
            ConsoleKeyInfo key;
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
        }

        private static void AddNote()
        {
            _notesStorage.AddNote();
        }

        private static void LoadNotes()
        {
            _notesReader = new NotesReader();
            _notesStorage = new NotesStorage();
            _notesStorage.Notes = _notesReader.LoadNotes();
        }

        private static void CloseNotepad()
        {
            _notesReader.SaveNotes(_notesStorage.Notes);
            Environment.Exit(0);
        }
    }
}