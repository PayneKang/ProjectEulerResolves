using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

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
            LargeNumberModel[] frac = BuildFractionResult(2, seeds, 0);
            Console.WriteLine(string.Format("{0} / {1} : {2}", frac[0], frac[1], MAXLEN + 1));
            int result = frac[0].Digits.Sum();
            Console.WriteLine(string.Format("Result is {0}", result));
        }
        static LargeNumberModel[] BuildFractionResult(int baseNum, int[] seeds,int len)
        {
            int index = len % seeds.Length;
            if (len == MAXLEN)
            {
                if (len == 0)
                    return new LargeNumberModel[] { new LargeNumberModel(baseNum.ToString()), new LargeNumberModel("1") };
                return new LargeNumberModel[] { new LargeNumberModel(seeds[index - 1].ToString()), new LargeNumberModel("1") };
            }
            int nextBase = seeds[index];
            len++;
            LargeNumberModel[] chdFrac = BuildFractionResult(nextBase, seeds, len);
            LargeNumberModel dividend = chdFrac[0];
            LargeNumberModel divisor = dividend * baseNum + chdFrac[1];
            return new LargeNumberModel[] { divisor, dividend };
        }
    }
}
