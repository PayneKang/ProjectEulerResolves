using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem021
{
    class Program
    {
        static FactorsGenerator fg = new FactorsGenerator();
        static void Main(string[] args)
        {
            long[] dArray = new long[10001];
            for (long i = 1; i <= 10000; i++)
            {
                dArray[i] = d(i);
            }
            long result = 0;
            for (long i = 1; i <= 10000; i++)
            {
                long pos = dArray[i];
                if (pos > 10000)
                    continue;
                if (pos < 1)
                    continue;
                if (i == dArray[pos] && i != dArray[i])
                {
                    Console.WriteLine(string.Format("Pare:{0} - {1}",i,dArray[i]));
                    result += i + dArray[i];
                }
            }
            result = result / 2;
            Console.WriteLine(result);
            Debug.WriteLine(result);
            Console.ReadLine();
        }
        static long d(long n)
        {
            List<long> divisors = fg.GeneratorDistinctDivisor(n);
            long result = 0;
            for (int i = 0; i < divisors.Count; i++)
            {
                if (divisors[i] < n)
                    result += divisors[i];
            }
            return result;
        }
    }
}
