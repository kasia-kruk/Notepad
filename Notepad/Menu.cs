using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class Menu
    {
        public List<string> MenuOptions { get; private set; }

        public int SelectedMenuIndex { get; set; }

        public Menu()
        {
            MenuOptions = new List<string>() 
            { 
                "Wyświetl notatki",
                "Dodaj notatkę",
                "Usuń notatkę",
                "Edytuj notatkę",
                "Wyjdź z programu"
            };
        }

        public void Display()
        {
            Console.Clear();

            for (int i = 0; i < MenuOptions.Count; i++)
            {
                if (i == SelectedMenuIndex)
                {
                    Console.WriteLine($">> {MenuOptions[i]} <<");
                }
                else
                {
                    Console.WriteLine(MenuOptions[i]);
                }
            }
        }
    }
}