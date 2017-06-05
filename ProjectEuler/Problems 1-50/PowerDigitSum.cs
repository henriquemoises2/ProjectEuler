using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEuler
{
    class PowerDigitSum : IProblem
    {
        private const string MENU_ENTRY = "Power Digit Sum";
        private const int BASE = 2;
        private const int POWER = 10;

        private int powerNumber;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                BigInteger number = BigInteger.Pow(BASE, powerNumber);
                long totalSum = DigitSum(number);
                Console.WriteLine("Total: " + totalSum);
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
            Console.WriteLine("Enter power number:");
            if (int.TryParse(Console.ReadLine(), out powerNumber))
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

        private long DigitSum(BigInteger number) 
        {
            long result = 0;
            char[] charArrayNumber = number.ToString().ToCharArray();
            foreach (char charNumber in charArrayNumber) 
            {
                result += (long)char.GetNumericValue(charNumber);
            }
            Console.WriteLine(result);
            return result;
        }

        #endregion
    }
}
