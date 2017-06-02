using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Utils
    {

        public static bool IsEven(double number)
        {
            return number % 2 == 0;
        }

        public static bool IsOdd(double number)
        {
            return number % 2 != 0;
        }

        public static double Factorial(double number)
        {
            double total = 1;
            for (double i = number; i > 1; i--)
            {
                total *= i;
            }
            return total;
        }

    }
}
