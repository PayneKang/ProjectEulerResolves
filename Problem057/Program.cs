using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem057
{
    class Program
    {
        static int MAXLEN = 99;
        static void Main(string[] args)
        {
            int result = 0;
            for (int i = 1; i <= 1000; i++)
            {
                MAXLEN = i;
                BigInteger[] frac = BuildFractionResult(1, 2, 0);
                if (frac[0].ToString().Length > frac[1].ToString().Length)
                {
                    result++;
                }
            }
            Console.WriteLine(string.Format("Result is {0}", result));
        }
        static BigInteger[] BuildFractionResult(int baseNum, int seed, int len)
        {
            if (len == MAXLEN)
            {
                if (len == 0)
                    return new BigInteger[] { baseNum, 1 };
                return new BigInteger[] { seed, 1 };
            }
            int nextBase = seed;
            len++;
            BigInteger[] chdFrac = BuildFractionResult(nextBase, seed, len);
            BigInteger dividend = chdFrac[0];
            BigInteger divisor = dividend * baseNum + chdFrac[1];
            return new BigInteger[] { divisor, dividend };
        }
    }
}
