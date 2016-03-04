using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class FactorialCalculator
    {
        private FactorialCalculator() { }
        public int Factorial(int Num)
        {
            int result = 1;
            for (int i = 1; i <= Num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
