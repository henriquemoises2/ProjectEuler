using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class MenuEnum
    {
        public static Dictionary<int, IProblem> menuOptions = new Dictionary<int, IProblem>()
        {
            {1, new SumMultiples()},
            {2, new FibonacciEvenOdd()},
            {3, new HighestPrimeFactor()},
            {4, new LastPalindromeProduct()},
            {5, new SmallestMultiple()},
            {6, new SumSquareDifference()},
            {7, new NthPrime()},
            {8, new LargestProductInSeries()},
            {9, new PythagorianTriplet()}
        };

    }
}
