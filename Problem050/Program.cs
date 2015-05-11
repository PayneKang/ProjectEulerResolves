using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem050
{
    class Program
    {
        static int[] primes;
        static int maxLength = 0;
        static PrimeGenerator pg = new PrimeGenerator();
        const int MAX = 1000000;
        static void Main(string[] args)
        {
            primes = pg.GetPrimesBelowOneMillion();
            int len = 2;
            int result = 0;
            bool foundResult = false;
            while (!foundResult)
            {
                for (int i = 0; i < primes.Length - len; i++)
                {
                    int sum = SumPrimes(i, len);
                    if (sum >= MAX)
                    {
                        if (i == 0)
                        {
                            foundResult = true;
                            break;
                        }
                        break;
                    }
                    if (primes.Contains(sum))
                        result = sum;
                }
                len++;
            }
            Console.WriteLine(string.Format("Result is {0}", result));
        }
        static int SumPrimes(int startIndex, int length)
        {
            int rlt = 0;
            for (int i = startIndex; i < startIndex + length; i++)
            {
                rlt += primes[i];
            }
            return rlt;
        }
    }
}
