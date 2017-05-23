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
                double solution = GetNthPrime(index);
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

        #region Private Methods

        private double GetNthPrime(int index)
        {
            double prime = 2;
            for (int i = 2; i <= index; i++) 
            {
                prime = GetNextPrime(prime);
            }
            return prime;
        }

        private double GetNextPrime(double prime)
        {
            for (double number = prime + 1; ; number++)
            {
                if (IsPrime(number))
                {
                    return number;
                }
            }
        }

        private bool IsPrime(double number)
        {
            if (number == 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }

            double boundary = (int)Math.Floor(Math.Sqrt(number));
            for (double i = 2; i <= boundary; i++)
            {
                if ((number % i == 0))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion


    }
}
