using ProjectEuler.Utils;
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

                for (double prime = 2; prime < upperLimit; prime = Prime.GetNextPrime(prime)) 
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
    }
}
