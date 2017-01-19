using Kang.Algorithm.BaseLib;
using Kang.Algorithm.BaseLib.PrimeChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem211
{
    class Program
    {
        static bool[] perfectSquare = new bool[64000001];
        static List<long> primes = new List<long>();
        static void BuildAllPerfectSquare()
        {
            long i = 1;
            while (i < 8000)
            {
                perfectSquare[i * i] = true;
                i++;
            }
        }
        static void Main(string[] args)
        {
            BuildAllPerfectSquare();
            long product = 1;
            long i = 1;
            while (product < 64000000)
            {
                i++;
                if (!MillerRabinCheck.isPseudoPrime(i))
                    continue;
                product *= i;
                primes.Add(i);
            }
        }
    }
}
