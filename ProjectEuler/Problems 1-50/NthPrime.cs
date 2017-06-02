using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class NthPrime : IProblem
    {
        private const string MENU_ENTRY = "Nth Prime Number";
        private int index = 0;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                double solution = Prime.GetNthPrime(index);
                Console.WriteLine("Result: " + solution);
                return true;
            }
            else
            {
                return false;
            }

        }

        public string GetMenuEntry()
        {
            return MENU_ENTRY;
        }

        public bool Introduction()
        {
            Console.WriteLine("Enter the prime index:");
            if (Int32.TryParse(Console.ReadLine(), out index))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}
