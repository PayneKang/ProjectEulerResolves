using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem070
{
    class Program
    {
        const int MAXNUM = 10000000;
        static void Main(string[] args)
        {
            PrimeGenerator pg = new PrimeGenerator();
            bool[] primes = pg.CheckPrimeNumber(MAXNUM);
            List<int> allPrimes = new List<int>();
            for (int i = 2; i < MAXNUM; i++)
            {
                if (primes[i])
                {
                    allPrimes.Add(i);
                }
            }
            int phi87109 = Phi(87109, allPrimes);
            int num = 1;
            for (int i = 1; i < MAXNUM; i++)
            {
                int phi = Phi(i, allPrimes);
                if(i % 100 == 0)
                    Console.WriteLine("Phi of {0} is {1}", i, phi);
            }
        }
        static int Phi(int num, List<int> primes)
        {
            int tmp = num;
            foreach (int p in primes)
            {
                if (num % p != 0)
                {
                    continue;
                }
                if (p > num)
                    break;
                tmp = tmp - tmp / p;
            }
            return tmp;
        }
    }
}
