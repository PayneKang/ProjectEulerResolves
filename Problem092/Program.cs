using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem092
{
    class Program
    {
        static Dictionary<long, object> ChainEnd89 = new Dictionary<long, object>();
        static Dictionary<long, object> ChainEnd1 = new Dictionary<long, object>();
        static void Main(string[] args)
        {
            int result = 0;
            for (int i = 1; i < 10000000; i++)
            {
                int chainEnd = GetChainEnd(i);
                if (chainEnd == 89)
                {
                    result++;
                }
            }
            Console.WriteLine(string.Format("Result is {0}", result));
        }
        static int GetChainEnd(long num)
        {
            long temp = num;
            while (true)
            {
                if (ChainEnd1.ContainsKey(temp))
                {
                    return 1;
                }
                if (ChainEnd89.ContainsKey(temp))
                {
                    return 89;
                }
                if (temp == 1)
                {
                    if (!ChainEnd1.ContainsKey(temp))
                        ChainEnd1.Add(temp, null);
                    return 1;
                }
                if (temp == 89)
                {
                    if (!ChainEnd89.ContainsKey(temp))
                        ChainEnd89.Add(temp, null);
                    return 89;
                }
                temp = GetNextChainNumber(temp);
            }
        }
        static long GetNextChainNumber(long num)
        {
            int[] digits = NumberUtils.SplitNumber(num, 1);
            long result = 0;
            foreach (int digit in digits)
            {
                result += digit * digit;
            }
            return result;
        }
    }
}
