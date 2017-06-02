using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Triplet
    {
        public double a, b, c;

        public Triplet(double aValue, double bValue, double cValue)
        {
            a = aValue;
            b = bValue;
            c = cValue;
        }
    }

    class PythagorianTriplet : IProblem
    {
        private const string MENU_ENTRY = "Pythagorian Triplet";
        private int solution;

        #region Overrides

        public bool Run()
        {

            if (Introduction())
            {
                Triplet triplet;
                for (int p = 1; p < solution; p++) 
                {
                    for (int q = 1; q < solution; q++) 
                    {
                        
                        triplet = GeneratePythagorianTriplet(p,q);
                        if (triplet != null)
                        {
                            Console.WriteLine(triplet.a + " " + triplet.b + " " + triplet.c);
                        }
                        if (triplet != null && IsSolution(triplet)) 
                        {
                            
                            Console.WriteLine("A: " + triplet.a + " B: " + triplet.b + " C: " + triplet.c);
                            Console.WriteLine("Solution: " + triplet.a * triplet.b * triplet.c);
                            return true;
                        }
                    }
                }
                return false;
            }
            else return false;
        }

        public string GetMenuEntry()
        {
            return MENU_ENTRY;
        }

        public bool Introduction()
        {
            Console.WriteLine("Enter the value x for which to compute the unique combination a+b+c=x where a<b<c and a^2+b^2=c^2 :");
            if (int.TryParse(Console.ReadLine(), out solution))
            {
                return true;
            }
            else return false;
        }

        #endregion

        #region Private Methods

        private Triplet GeneratePythagorianTriplet(int p, int q)
        {
            if (p > q)
            {
                double a = 2 * p * q;
                double b = Math.Pow(p, 2) - Math.Pow(q, 2);
                double c = Math.Pow(p, 2) + Math.Pow(q, 2);
                Triplet triplet = new Triplet(a, b, c);
                return triplet;
            }
            else return null;
        }

        private bool IsSolution(Triplet triplet) 
        {
            return (triplet.a + triplet.b + triplet.c == solution);
        }

        #endregion

    }
}
