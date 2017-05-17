using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class HighestPrimeFactor : IProblem
    {
        private const string menuEntry = "Highest Prime Factor";
        private double numberToCompute;

        public bool Run()
        {
            double currentPrime;
            double boundry;
            double maxPrime = 2;

            if (Introduction())
            {
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
                Console.WriteLine("Result: " + maxPrime);
                return true;
            }
            else return false;
        }

        public string GetMenuEntry()
        {
            return menuEntry;
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

        public void ShowError()
        {
            Console.WriteLine("Invalid value inserted.");
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
            for (double i = 2; i < boundary; i++)
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

    }
}
