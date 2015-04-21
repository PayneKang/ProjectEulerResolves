using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem046
{
    class Program
    {
        static bool[] squares = new bool[100000001];
        static int[] primes;
        static bool[] primeTag;
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                squares[i * i] = true;
            }
            squares[0] = false;
            PrimeGenerator pg = new PrimeGenerator();
            primes = pg.GetPrimesBelowOneMillion();
            primeTag = pg.CheckPrimeNumber(1000000);
            int squTwice = 0;
            int firstOdd = 0;
            bool pass = false;
            for (int i = 3; ; i += 2)
            {
                if (primeTag[i])
                    continue;
                pass = false;
                foreach (int prime in primes)
                {
                    if (i <= prime)
                        break;
                    squTwice = i - prime;
                    if (squTwice % 2 != 0)
                        continue;
                    squTwice = squTwice / 2;
                    if (!squares[squTwice])
                        continue;
                    pass = true;
                    break;
                }
                if (pass)
                    continue;
                firstOdd = i;
                break;
            }
            Console.WriteLine(string.Format("Result is {0}", firstOdd));
        }
    }
}
