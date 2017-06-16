using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class AmicableNumbers : IProblem
    {
        private const string MENU_ENTRY = "Amicable Numbers";
        private double roofNumber;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                double total = CountAmicableNumbers(roofNumber);
                Console.WriteLine("Total Sum Amicable Numbers: " + total);
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
            Console.WriteLine("Enter the roof: ");
            if (double.TryParse(Console.ReadLine(), out roofNumber))
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

        private double CountAmicableNumbers(double roofNumber)
        {
            List<int> amicableList = new List<int>();
            int sumDivisors, sumDivisorsPair;
            double total = 0;

            for (int i = 1; i <= roofNumber; i++)
            {
                sumDivisors = GetSumDivisors(i);
                sumDivisorsPair = GetSumDivisors(sumDivisors);

                if (i == sumDivisorsPair && i != sumDivisors && !amicableList.Exists(number => number == i))
                {
                    amicableList.Add(i);

                }
            }

            foreach (double number in amicableList)
            {
                total += number;
            }

            return total;
        }

        private int GetSumDivisors(int number)
        {
            int divisorsSum = 0;
            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    divisorsSum += i;
                }
            }
            return divisorsSum;
        }

        #endregion
    }
}
