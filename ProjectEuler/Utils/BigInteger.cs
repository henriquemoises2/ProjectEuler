using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class BigIntegerUtils
    {

        public static BigInteger Factorial(double number) 
        {
            BigInteger total = new BigInteger(1);
            BigInteger currentNumber = new BigInteger(number);
            while (currentNumber > 1) 
            {
                total = BigInteger.Multiply(total, currentNumber);
                currentNumber--;
            }
            return total;
        
        }

    }
}
