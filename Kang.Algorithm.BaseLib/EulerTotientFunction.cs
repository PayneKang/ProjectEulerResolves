using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class EulerTotientFunction
    {
        static int[] primes;
        public static int Calculate(int num)
        {
            if (primes == null)
            {
                primes = new PrimeGenerator().GetPrimesBelowOneMillion();
            }
            if (primes.Contains(num))
            {
                return num - 1;
            }
            if (num % 2 == 0 && (num / 2) % 2 == 1)
            {
                return Calculate(num / 2);
            }

            int tmp = num;
            foreach (int p in primes)
            {
                if (num % p != 0)
                {
                    continue;
                }
                if (p > num)
                    break;
                tmp = tmp - tmp / p;
            }
            return tmp;
        }
    }
}
