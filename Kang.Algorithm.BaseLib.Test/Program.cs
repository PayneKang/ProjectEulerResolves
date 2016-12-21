using System.Diagnostics;
using Kang.Algorithm.BaseLib.PrimeChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MeisselLehmerPrimeCounter pc = new MeisselLehmerPrimeCounter();

            for(int i = 9; i <= 15; i++){
                Stopwatch sw = new Stopwatch();
                sw.Start();
                long num = (long)Math.Pow(10, i);
                long rlt = pc.Lehmer(num);
                sw.Stop();
                Console.WriteLine("Prime count below 1e{0} \tis {1} \t; timeused:{2}ms",i,rlt,sw.ElapsedMilliseconds);
            }
            Console.Read();
        }
    }
}
