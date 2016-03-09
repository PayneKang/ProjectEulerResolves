using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem087
{
    class Program
    {
        static int MAX = 50000000;
        //static int MAX = 50;
        static void Main(string[] args)
        {
            int[] primes = new PrimeGenerator().GetPrimesBelowOneMillion();
            int resultCount = 0;
            int d = 0;
            int t = 0;
            int s = 0;
            List<int> result = new List<int>();
            while (true)
            {
                int sp = primes[s];
                int sr = (int)Math.Pow(sp, 4);
                if (sr >= MAX)
                    break;
                t = 0;
                while (true)
                {
                    int tp = primes[t];
                    int tr = (int)Math.Pow(tp, 3);
                    if (sr + tr >= MAX)
                        break;
                    d = 0;
                    while (true)
                    {
                        int dp = primes[d];
                        int dr = (int)Math.Pow(dp, 2);
                        if (sr + tr + dr >= MAX)
                            break;
                        d++;
                        result.Add(sr + tr + dr);
                    }
                    t++;
                }
                s++;
            }
            resultCount = result.Distinct().Count();
            Console.WriteLine("Result is {0}", resultCount);
        }
    }
}
