using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

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
                LargeNumberModel[] frac = BuildFractionResult(1, 2, 0);
                if (frac[0].NumberLength > frac[1].NumberLength)
                {
                    result++;
                }
            }
            Console.WriteLine(string.Format("Result is {0}", result));
        }
        static LargeNumberModel[] BuildFractionResult(int baseNum, int seed, int len)
        {
            if (len == MAXLEN)
            {
                if (len == 0)
                    return new LargeNumberModel[] { new LargeNumberModel(baseNum.ToString()), new LargeNumberModel("1") };
                return new LargeNumberModel[] { new LargeNumberModel(seed.ToString()), new LargeNumberModel("1") };
            }
            int nextBase = seed;
            len++;
            LargeNumberModel[] chdFrac = BuildFractionResult(nextBase, seed, len);
            LargeNumberModel dividend = chdFrac[0];
            LargeNumberModel divisor = dividend * baseNum + chdFrac[1];
            return new LargeNumberModel[] { divisor, dividend };
        }
    }
}
