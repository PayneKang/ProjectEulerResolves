using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.PrimeChecker;
using Kang.Algorithm.BaseLib;

namespace Problem501
{
    class Program
    {
        private const double oneOfThree = 1d/3d;
        private const long Terminal = 1000000000000;
        private static int[] primes;
        static Dictionary<long,long> pcDic = new Dictionary<long, long>(); 
        private static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MeisselLehmerPrimeCounter pc = new MeisselLehmerPrimeCounter();
            primes = new PrimeGenerator().GetPrimesBelowOneMillion().ToArray();
            long count = 0;
            // 计算一个质因数的值
            for (int i = 0; i < primes.Length; i++)
            {
                long prime = primes[i];
                long num = (long) Math.Pow(prime, 7);
                if (num > Terminal)
                    break;
                count++;
            }
            // 计算两个质因数的值
            for (int i = 0; i < primes.Length; i++)
            {
                long num1 = primes[i];
                long tmp = num1 * num1 * num1;
                if (tmp > Terminal)
                    break;
                long maxThird = Terminal / tmp;
                int diff = maxThird >= num1 ? 1 : 0;
                long primeCount = 0;
                if (pcDic.ContainsKey(maxThird))
                    primeCount = pcDic[maxThird];
                else
                {
                    primeCount = pc.Lehmer(maxThird);
                    pcDic.Add(maxThird,primeCount);
                }
                count += primeCount - diff;
            }

            // 计算三个质因数的值
            for (int i = 0; i < primes.Length; i++)
            {
                long n = 0;
                long num1 = primes[i];
                long tmp = num1*(num1+1)*(num1+2);
                if (tmp > Terminal)
                    break;
                for (int j = i + 1; j < primes.Length; j++)
                {
                    long num2 = primes[j];
                    tmp = num1*num2*(num2+1);
                    if (tmp > Terminal)
                        break;
                    long end = Terminal / (num1 * num2);
                    long start = num2;
                    if (start >= end)
                        break;
                    long pcend = 0;
                    if (pcDic.ContainsKey(end))
                        pcend = pcDic[end];
                    else
                    {
                        pcend = pc.Lehmer(end);
                        pcDic.Add(end, pcend);
                    }
                    long pcstart = 0;
                    if (pcDic.ContainsKey(start))
                        pcstart = pcDic[start];
                    else
                    {
                        pcstart = pc.Lehmer(start);
                        pcDic.Add(start, pcstart);
                    }
                    long primeCount = pcend - pcstart;
                    count += primeCount;
                }


            }
            sw.Stop();

            Console.WriteLine("Result is {0} timeUsed {1} seconds",count,sw.Elapsed.TotalSeconds);

        }


        static long FindMaxDivisorNumber(long num)
        {
            double result = Math.Pow(num, oneOfThree);
            return (long)result;
        }
        static long getPrimeCount(long num)
        {
            int[] pgs = new PrimeGenerator().GetPrimesBelowOneMillion();
            long count = 0;
            foreach (int i in pgs)
            {
                if (i >= num)
                    break;
                count++;
            }
            return count;
        }
    }
}
