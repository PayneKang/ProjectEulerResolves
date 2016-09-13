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
        private static int[] Phis = new int[MAXNUM];
        static bool[] primes = new PrimeGenerator().CheckPrimeNumber(MAXNUM);

        static void Main(string[] args)
        {
            Phis[0] = 0;
            Phis[1] = 1;
            for (int i = 2; i < MAXNUM; i++)
            {
                Phis[i] = i - 1;
            }
            for (int i = 2; i < MAXNUM; i++)
            {
                if (!primes[i])
                {
                    continue;
                }
                int index = i + i;
                int count = 1;
                while (index < MAXNUM)
                {
                    Phis[index] -= count;
                    count ++;
                    index += i;
                }
            }
        }
    }
}
