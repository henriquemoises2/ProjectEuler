using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class SumSquareDifference : IProblem
    {

        private const string MENU_ENTRY = "Sum of Squares/Square of sum difference";

        private double lowerLimit;
        private double upperlimit;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                double sumOfSquares = SumOfSquares(lowerLimit,upperlimit);
                double squareOfSum = SquareOfSum(lowerLimit,upperlimit);
                double total = squareOfSum - sumOfSquares;
                Console.WriteLine("Total: " + total);
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
            if (double.TryParse(Console.ReadLine(), out lowerLimit))
            {
                Console.WriteLine("Enter the higher limit:");
                if (double.TryParse(Console.ReadLine(), out upperlimit) && upperlimit >= lowerLimit)
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

        private double SumOfSquares(double lowerLimit, double upperLimit){

            double total = 0;
            for (double number = lowerLimit; number <= upperLimit; number++) 
            {
                total += Math.Pow(number,2);            
            }

            return total;
        }

        private double SquareOfSum(double lowerLimit, double upperLimit)
        {

            double total = 0;
            for (double number = lowerLimit; number <= upperLimit; number++)
            {
                total += number;
            }

            return Math.Pow(total,2);
        }

        #endregion

    }
}
