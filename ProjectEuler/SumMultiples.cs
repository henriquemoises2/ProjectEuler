using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class SumMultiples : IProblem
    {
        private const string menuEntry = "Multiples";

        private int numberMultiplesToCompute;
        private List<int> multiplesToCompute;
        private int roof;
        private int total = 0;


        public bool Run()
        {
            if (Introduction())
            {
                for (int i = 1; i < roof; i++) 
                {
                    if (multiplesToCompute.Any(number => i % number == 0))
                    {
                        total += i;
                    }
                
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
            Console.WriteLine("Enter the roof:");
            if (Int32.TryParse(Console.ReadLine(), out roof))
            {
                Console.WriteLine("Enter the number of multiples to compute:");
                if (Int32.TryParse(Console.ReadLine(), out numberMultiplesToCompute))
                {
                    int multiple;
                    multiplesToCompute = new List<int>();

                    Console.WriteLine("Enter the multiples:");
                    for (int i = 0; i < numberMultiplesToCompute; i++)
                    {
                        if (Int32.TryParse(Console.ReadLine(), out multiple))
                        {
                            multiplesToCompute.Add(multiple);
                        }
                        else
                        {
                            break;
                        }

                    }
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

    }
}
