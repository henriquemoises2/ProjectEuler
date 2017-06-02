using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class HighestPrimeFactor : IProblem
    {
        private const string MENU_ENTRY = "Highest Prime Factor";
        private double numberToCompute;

        #region Overrides

        public bool Run()
        {
            
            if (Introduction())
            {
                double maxPrime = ComputeHighestPrime(numberToCompute);
                Console.WriteLine("Result: " + maxPrime);
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
            Console.WriteLine("Enter the number to compute the highest prime factor:");
            if (double.TryParse(Console.ReadLine(), out numberToCompute))
            {
                return true;
            }
            else return false;
        }

        #endregion

        #region Private Methods

        private double ComputeHighestPrime(double number)
        {
            double boundry = (int)Math.Floor(Math.Sqrt(number));
            double maxPrime = 2;
            
            for (double currentPrime = 2; currentPrime < boundry; currentPrime = Prime.GetNextPrime(currentPrime))
            {
                if (number % currentPrime == 0)
                {
                    maxPrime = currentPrime;
                    while (number % currentPrime == 0)
                    {
                        number /= currentPrime;
                    }
                }
            }
            return maxPrime;
        }

        #endregion
    }
}
