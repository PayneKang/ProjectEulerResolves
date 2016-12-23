using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;
using Kang.Algorithm.BaseLib;

namespace Problem065
{
    class Program
    {
        static int MAXLEN = 99;
        static int[] seeds;
        static void Main(string[] args)
        {
            seeds = new int[300];
            for (int i = 0; i < 100; i++)
            {
                if (i % 3 == 1)
                {
                    seeds[i] = ((i / 3) + 1) * 2;
                    continue;
                }
                seeds[i] = 1;
            }
            BigInteger[] frac = BuildFractionResult(2, seeds, 0);
            Console.WriteLine(string.Format("{0} / {1} : {2}", frac[0], frac[1], MAXLEN + 1));
            BigInteger tmp = frac[0];
            
            long result = NumberUtils.SumDigits(frac[0]);
            Console.WriteLine(string.Format("Result is {0}", result));
        }
        static BigInteger[] BuildFractionResult(int baseNum, int[] seeds,int len)
        {
            int index = len % seeds.Length;
            if (len == MAXLEN)
            {
                if (len == 0)
                    return new BigInteger[] { baseNum, 1 };
                return new BigInteger[] { seeds[index - 1], 1 };
            }
            int nextBase = seeds[index];
            len++;
            BigInteger[] chdFrac = BuildFractionResult(nextBase, seeds, len);
            BigInteger dividend = chdFrac[0];
            BigInteger divisor = dividend * baseNum + chdFrac[1];
            return new BigInteger[] { divisor, dividend };
        }
    }
}
