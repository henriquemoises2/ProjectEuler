using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class LatticePaths : IProblem
    {
        private const string MENU_ENTRY = "Lattice Paths";

        private int gridSize;

        #region Overrides

        public bool Run()
        {

            if (Introduction())
            {
                double totalPaths = BinomialCoefficient(gridSize);
                Console.WriteLine("Total Paths: " + totalPaths);
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
            Console.WriteLine("Enter grid size: ");
            gridSize = Int32.Parse(Console.ReadLine());
            return true;
        }

        #endregion

        #region Private Methods

        private double BinomialCoefficient(int gridSize)
        {
            double n = gridSize * 2;
            double k = gridSize;
            double total = Utils.Factorial(n) / (Utils.Factorial(k) * Utils.Factorial(n - k));
            return total;
        }

        #endregion
    }

}
