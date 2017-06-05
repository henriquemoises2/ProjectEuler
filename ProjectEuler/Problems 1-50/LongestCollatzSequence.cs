using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class LongestCollatzSequence : IProblem
    {
        private const string MENU_ENTRY = "Longest Collatz Sequence";

        private double startingNumber;

        #region Overrides

        public bool Run()
        {
           
            if (Introduction())
            {
                double highestChainNumber = ComputeHighestChainNumber(startingNumber);
                Console.WriteLine("Highest Chain Number: " + highestChainNumber);
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
            Console.WriteLine("Enter the highest starting number: ");
            startingNumber = Int32.Parse(Console.ReadLine());
            return true;
        }

        #endregion

        #region Private Methods

        private double ComputeHighestChainNumber(double startingNumber) 
        {
            double highestChainLength = 0;
            double highestChainNumber = 0;
            double[] chain;
            double[] highestChain = {};

            for (double i = 2; i < startingNumber ; i++) 
            {
                chain = GetChain(i);
                if (chain.Count() > highestChainLength) 
                {
                    Console.WriteLine("Number: " + i + " Length: " + chain.Length);
                    highestChainLength = chain.Count();
                    highestChainNumber = i;
                    highestChain = chain;
                }
            }
            PrintChain(highestChain);
            return highestChainNumber;
        }

        private double[] GetChain(double number)
        {
            List<double> chain = new List<double>();
            chain.Add(number);
            while (number > 1)
            {
                number = GetNextSequenceElement(number);
                chain.Add(number);
            }
            return chain.ToArray();
        }

        private double GetNextSequenceElement(double number)
        {
            if (Utils.IsEven(number))
            {
                return number / 2;
            }
            else
            {
                return ((3 * number) + 1);
            }
        }

        private void PrintChain(double[] chain) 
        {
            Console.Write("Chain: ");
            foreach (double elem in chain) 
            {
                Console.Write(" " + elem);
            }
            Console.WriteLine();
        }

        #endregion

    }
}
