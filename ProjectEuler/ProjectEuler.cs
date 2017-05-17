using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class ProjectEuler
    {
        static void Main(string[] args)
        {
            int opcaoSeleccionada;
            Console.WriteLine("Welcome to Project Euler.");

            do
            {

                Console.WriteLine("Choose an Option:");
                ShowOptions();

                if (Int32.TryParse(Console.ReadLine(), out opcaoSeleccionada))
                {
                    LimpaConsola();
                    if (MenuEnum.menuOptions.ContainsKey(opcaoSeleccionada))
                    {
                        MenuEnum.menuOptions[opcaoSeleccionada].Run();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option chosen.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option chosen.");
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static void ShowOptions()
        {
            foreach (KeyValuePair<int, IProblem> entry in MenuEnum.menuOptions)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value.GetMenuEntry());
            }
        }

        private static void LimpaConsola()
        {
            Console.Clear();
        }

    }
}
