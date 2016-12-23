using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class NumberUtils
    {
        public static int ToInt(string numStr)
        {
            return int.Parse(numStr.TrimStart(new char[] { '0' }));
        }
        /// <summary>
        /// 将数字分割成几个指定长度的数字
        /// </summary>
        /// <param name="number"></param>
        /// <param name="splitLength"></param>
        /// <returns></returns>
        public static int[] SplitNumber(long number,int splitLength)
        {
            int splitNumber = (int)Math.Pow(10,splitLength);
            List<int> result = new List<int>();
            long temp = number;
            while (temp > 0)
            {
                result.Add((int)(temp % splitNumber));
                temp = temp / splitNumber;
            }
            return result.ToArray();
        }
        public static int GetNumberLength(long number)
        {
            int length = 0;
            while (number > 0)
            {
                length++;
                number /= 10;
            }
            return length;
        }

        public static long GCD(long numa, long numb)
        {
            FactorsGenerator fg = new FactorsGenerator();
            List<long> fa = fg.GeneratorFactors(numa);
            List<long> fb = fg.GeneratorFactors(numb);
            int ai = 0,bi = 0;
            List<long> crossf = new List<long>();
            while (ai < fa.Count && bi < fb.Count)
            {
                long a = fa[ai];
                long b = fb[bi];
                if (a == b)
                {
                    crossf.Add(a);
                    ai++;
                    bi++;
                    continue;
                }
                if (a < b)
                {
                    ai++;
                    continue;
                }
                if (a > b)
                {
                    bi++;
                    continue;
                }
            }
            long result = 1;
            foreach (var c in crossf)
            {
                result *= c;
            }
            return result;
        }

        public static long SumDigits(BigInteger num)
        {
            long sum = 0;
            while (num > 0)
            {
                sum += (long)(num % 10);
                num = num / 10;
            }
            return sum;
        }
    }
}
