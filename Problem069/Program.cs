using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem069
{
    class Program
    {
        static FactorsGenerator fg = new FactorsGenerator();
        public class NumberModel
        {
            public int Val { get; set; }
            public int RPCount { get; set; }
        }
        const int NUMCOUNT = 1000000;
        static void Main(string[] args)
        {
            PrimeGenerator pg = new PrimeGenerator();
            int[] primes = pg.GetPrimesBelowOneMillion();
            int rlt = 1;
            int tmp = 1;
            foreach(int p in primes){
                tmp = tmp * p;
                 if (tmp >= NUMCOUNT)
                 {
                     break;
                 }
                 rlt = tmp;
            }
            Console.WriteLine(rlt);
        }
    }
}
