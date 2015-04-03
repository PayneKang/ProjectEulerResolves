using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem027
{
    class Program
    {
        const int MAX_PRIME = 3000000;
        private static bool[] primes;
        static void Main(string[] args)
        {
            GetPrimeMark();
            List<long> maxResult = new List<long>();
            int maxA = 0, maxB = 0;
            for(int a = -1000; a <= 1000; a++){
                for (int b = -1000; b <= 1000; b++)
                {
                    List<long> result = GetPrimeResult(a, b);
                    if (result.Count <= maxResult.Count)
                        continue;
                    maxResult = result;
                    maxA = a;
                    maxB = b;
                }
            }
            Console.WriteLine(maxA * maxB);
        }
        static void GetPrimeMark()
        {
            primes = new bool[MAX_PRIME + 1];
            for (int i = 0; i < MAX_PRIME + 1; i++)
            {
                primes[i] = true;
            }
            PrimeGenerator pg = new PrimeGenerator();
            int sqrt = (int)Math.Sqrt(MAX_PRIME);
            primes[0] = false;
            primes[1] = false;
            for (int i = 2; i < sqrt; i++)
            {
                int tempPos = i * 2;
                while (tempPos < MAX_PRIME)
                {
                    primes[tempPos] = false;
                    tempPos += i;
                }
            }
        }
        static long CalculateResult(int a, int b, int n)
        {
            return n * n + a * n + b;
        }
        static List<long> GetPrimeResult(int a, int b)
        {
            int EndN = Math.Max(Math.Abs(a), Math.Abs(b));
            List<long> result = new List<long>();
            for (int n = 0; n <= EndN; n++)
            {
                long calcRlt = CalculateResult(a, b, n);
                if (calcRlt < 2)
                    break;
                if (!primes[calcRlt])
                    break;
                result.Add(calcRlt);                   
            }
            return result;
        }
    }
}
