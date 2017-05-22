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
                ClearDisplay();
                Console.WriteLine("Choose an Option:");
                ShowOptions();

                if (Int32.TryParse(Console.ReadLine(), out opcaoSeleccionada) && MenuEnum.menuOptions.ContainsKey(opcaoSeleccionada))
                {
                    ClearDisplay();
                    if (!MenuEnum.menuOptions[opcaoSeleccionada].Run())
                    {
                        ShowError();
                    }
                }
                else
                {
                    ShowMenuError();
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

        private static void ClearDisplay()
        {
            Console.Clear();
        }

        public static void ShowMenuError()
        {
            Console.WriteLine("Invalid menu option chosen.");
        }

        public static void ShowError()
        {
            Console.WriteLine("Invalid value inserted.");
        }

    }
}
