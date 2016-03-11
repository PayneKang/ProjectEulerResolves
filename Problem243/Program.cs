using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem243
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeGenerator pg = new PrimeGenerator();
            double target = 15499d/94744d;
            double totient = 1d;
            double denominator = 1d;
            long answer = 0;
            for (int p = 2; ; )
            {
                totient *= p - 1;
                denominator *= p;
                do
                {
                    p++;
                }
                while (!pg.CheckPrime(p));

                if (totient / denominator < target)
                {
                    for (int j = 1; j < p; j++)
                    {
                        if ((j * totient) / (j * denominator - 1) < target)
                        {
                            answer = j * (long)denominator;
                            Console.WriteLine("Result is {0}", answer);
                            return;
                        }
                    }
                }
            }
        }
    }
}
