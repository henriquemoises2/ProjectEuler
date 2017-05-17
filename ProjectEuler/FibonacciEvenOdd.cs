using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class FibonacciEvenOdd : IProblem
    {
        private const string menuEntry = "Fibonnaci Even/Odd Sum";

        private long maxFibonacciNumber;
        private long total = 0;
        private long previousNumber = 1;
        private long actualNumber = 2;
        private long nextNumber;
        private bool isEven;
        private string parityInput;

        public bool Run()
        {
            if (Introduction())
            {
                if (isEven)
                {
                    total += actualNumber;
                }
                else
                {
                    total += previousNumber;
                }

                while (nextNumber < maxFibonacciNumber)
                {
                    nextNumber = ComputeNextFibonacciValue(previousNumber, actualNumber);
                    if (isEven)
                    {
                        if (nextNumber % 2 == 0)
                        {
                            total += nextNumber;
                        }
                    }
                    else if (nextNumber + 1 % 2 == 0)
                    {
                        total += nextNumber;
                    }
                    Console.WriteLine(nextNumber);
                    previousNumber = actualNumber;
                    actualNumber = nextNumber;
                }
                Console.WriteLine("Total: " + total);
                return true;
            }
            else
            {
                ShowError();
                return false;
            }

        }

        public string GetMenuEntry()
        {
            return menuEntry;
        }

        public bool Introduction()
        {
            Console.WriteLine("Enter the maximum value for a Fibonacci number:");
            if (Int64.TryParse(Console.ReadLine(), out maxFibonacciNumber))
            {
                Console.WriteLine("Computed values are odd or even:");
                parityInput = Console.ReadLine().ToLower();
                if (parityInput == "even")
                {
                    isEven = true;
                    return true;
                }
                else if (parityInput == "odd")
                {
                    isEven = false;
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

        public void ShowError()
        {
            Console.WriteLine("Wrong value inserted.");
        }

        private long ComputeNextFibonacciValue(long previousNumber, long actualNumber)
        {
            return previousNumber + actualNumber;
        }

    }
}
