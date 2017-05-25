using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class HighlyDivisibleTriangular : IProblem
    {
        private const string MENU_ENTRY = "Highly Divisible Triangular Number";

        private int numberDivisors;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                double triangleNumber = 0;
                
                int i = 0;
                while (NumberOfDivisors(triangleNumber) <= numberDivisors) 
                {
                    triangleNumber += i;
                    i++;
                }
                Console.WriteLine(triangleNumber);
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
            Console.WriteLine("Enter the number of divisors:");
            if (int.TryParse(Console.ReadLine(), out numberDivisors))
            {
                return true;
            }
            else return false;
        }

        #endregion

        #region Private Methods

        private double NumberOfDivisors(double number) 
        {
            List<PrimeFactor> factorization = PrimeFactor.PrimeFactorization(number);
            double numberDivisors = 1;
            foreach (PrimeFactor factor in factorization) 
            {
                numberDivisors *= (factor.p + 1);
            }
            return numberDivisors;  
        }

        #endregion


    }
}
