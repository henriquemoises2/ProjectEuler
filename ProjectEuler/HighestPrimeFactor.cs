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

        private double GetNextPrime(double prime)
        {
            for (double number = prime + 1;;number++)
            {
                if (IsPrime(number))
                {
                    return number;
                }
            }
        }

        private double ComputeHighestPrime(double number) 
        {
            double currentPrime;
            double boundry;
            double maxPrime = 2;

            boundry = (int)Math.Floor(Math.Sqrt(numberToCompute));
            for (currentPrime = 2; currentPrime < boundry; currentPrime = GetNextPrime(currentPrime))
            {
                if (numberToCompute % currentPrime == 0)
                {
                    maxPrime = currentPrime;
                    while (numberToCompute % currentPrime == 0)
                    {
                        numberToCompute /= currentPrime;
                    }
                }
            }
            return maxPrime;
        }

        #endregion
    }
}
