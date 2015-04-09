using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;
using Kang.Algorithm.BaseLib.Models;

namespace Problem030
{
    class Program
    {
        const int CALC_LENGTH = 5;
        static long[] pwDigits;
        static void Main(string[] args)
        {
            // 创建每一个数字的对应次方
            pwDigits = new long[10];
            for (int i = 0; i < 10; i++)
            {
                pwDigits[i] = (long)Math.Pow(i, CALC_LENGTH);
            }
            long end = (long)Math.Pow(9,5) * 6;
            List<long> result = new List<long>();
            for (long i = 2; i < end; i++)
            {
                int chk = CheckSumPowerEquals(i, CALC_LENGTH);
                if (chk == 0)
                    result.Add(i);
            }
            Console.WriteLine(result.Sum());
        }
        static int CheckSumPowerEquals(long x, int y)
        {
            int[] splits = NumberUtils.SplitNumber(x, 1);
            long pw = 0;
            foreach (int num in splits)
            {
                pw += pwDigits[num];
                if (pw > x)
                {
                    return 1;
                }
            }
            if (pw == x)
                return 0;
            return -1;
        }
    }
}
