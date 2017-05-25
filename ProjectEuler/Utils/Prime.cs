using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    class PrimeFactor
    {
        public double n { get; set; }
        public double p { get; set; }

        public PrimeFactor(double baseNum)
        {
            n = baseNum;
        }

        public PrimeFactor(double baseNum, double expNum)
        {
            n = baseNum;
            p = expNum;
        }

        public double GetValue()
        {
            return Math.Pow(n, p);
        }

        public static List<PrimeFactor> PrimeFactorization(double number) 
        {
            List<PrimeFactor> factorList = new List<PrimeFactor>();
            int power = 0;
            for (double currentPrime = 2; currentPrime <= number; currentPrime = Prime.GetNextPrime(currentPrime))
            {
                if (number % currentPrime == 0)
                {
                    PrimeFactor factor = new PrimeFactor(currentPrime);
                    factor.n = currentPrime;
                    power = 0;
                    while (number % currentPrime == 0)
                    {
                        number /= currentPrime;
                        power++;
                    }
                    factor.p = power;
                    //Console.WriteLine("Factor: " + factor.n + " " + factor.p);
                    factorList.Add(factor);
                }
            }
            return factorList;
        }
    }

    static class Prime
    {
        public static bool IsPrime(double number)
        {
            if (number == 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }

            double boundary = (int)Math.Floor(Math.Sqrt(number));
            for (double i = 2; i <= boundary; i++)
            {
                if ((number % i == 0))
                {
                    return false;
                }
            }
            return true;
        }

        public static double GetNextPrime(double prime)
        {
            for (double number = prime + 1; ; number++)
            {
                if (Prime.IsPrime(number))
                {
                    return number;
                }
            }
        }

        public static double GetNthPrime(int index)
        {
            double prime = 2;
            for (int i = 2; i <= index; i++) 
            {
                prime = GetNextPrime(prime);
            }
            return prime;
        }

        
    }
}
