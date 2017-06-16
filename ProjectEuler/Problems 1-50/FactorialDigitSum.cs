using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class FactorialDigitSum : IProblem
    {
        private const string MENU_ENTRY = "Factorial Digit Sum";

        private int factorialNumber;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                double totalSum = FactorialSum();
                Console.WriteLine("Total Sum: " + totalSum);
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
            Console.WriteLine("Enter the factorial number: ");
            if (int.TryParse(Console.ReadLine(), out factorialNumber))
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

        private double FactorialSum() 
        {
            double total = 0;
            BigInteger factorial = BigIntegerUtils.Factorial(factorialNumber);
            int[] digits = Array.ConvertAll(factorial.ToString().ToCharArray(), elem => (int)(char.GetNumericValue(elem)));
            foreach (int digit in digits) 
            {
                total += digit;
            }

            return total;
        }

        #endregion

    }
}
