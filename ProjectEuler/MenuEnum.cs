﻿using System;
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
            {3, new HighestPrimeFactor()}
        };

    }
}