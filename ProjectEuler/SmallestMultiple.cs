using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class SmallestMultiple : IProblem
    {
        private const string MENU_ENTRY = "Smallest Multiple";
        private const double MAX_NUMBER = 10000000000;

        private int limitLower;
        private int limitHigher;
        private HighestPrimeFactor highesPrimeFactorManager;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                double iterNumber = limitLower;
                double result = iterNumber++;
                for (iterNumber = limitLower + 1; iterNumber < limitHigher; iterNumber++) 
                {
                    result = LeastCommonMultiple(result, iterNumber);
                }
                Console.WriteLine("Result: " + result);
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
            Console.WriteLine("Enter the lower limit:");
            if (Int32.TryParse(Console.ReadLine(), out limitLower))
            {
                Console.WriteLine("Enter the higher limit:");
                if (Int32.TryParse(Console.ReadLine(), out limitHigher) && limitHigher >= limitLower)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Private Methods

        private double GreatestCommonDivisor(double number1, double number2) 
        {
            double d = 0, g;

            while (IsEven(number1) && IsEven(number2)) 
            {
                number1 /= 2;
                number2 /= 2;
                d++;
            }

            while (number1 != number2)
            {
                if (IsEven(number1)) 
                {
                    number1 /= 2;
                }
                else if (IsEven(number2)) 
                { 
                    number2 /= 2;
                }
                else if (number1 > number2)
                {
                    number1 = (number1 - number2) / 2;
                }
                else
                {
                    number2 = (number2 - number1) / 2;
                }
            }
            g = number1;
            return g * Math.Pow(2, d);
        }

        private double LeastCommonMultiple(double number1, double number2)
        {
            return (Math.Abs(number1) / GreatestCommonDivisor(number1, number2)) * Math.Abs(number2);
        }

        private bool IsEven(double number) 
        {
            return number % 2 == 0; 
        }

        #endregion

    }
}
