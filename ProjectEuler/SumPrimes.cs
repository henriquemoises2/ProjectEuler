using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class SumPrimes : IProblem
    {
        private const string MENU_ENTRY = "Summation of primes";

        private double upperLimit;

        #region Overrides

        public bool Run()
        {
            double total = 0;

            if (Introduction())
            {

                for (double prime = 2; prime < upperLimit; prime = GetNextPrime(prime)) 
                {
                    Console.WriteLine(prime);
                    total += prime;
                }
                Console.WriteLine("Total: " + total);
                return true;
            }
            else return false;
        }

        public string GetMenuEntry()
        {
            return MENU_ENTRY;
        }

        public bool Introduction()
        {
            Console.WriteLine("Enter the upper limit value:");
            if (double.TryParse(Console.ReadLine(), out upperLimit))
            {
                return true;
            }
            else return false;
        }

        #endregion

        #region Private Methods

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
