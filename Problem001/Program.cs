using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem001
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int sum = SumDivisibleBy(3, 999) + SumDivisibleBy(5, 999) - SumDivisibleBy(15, 999);
            sw.Stop();
            Console.WriteLine("Result is {0} , timeused {1}ms",sum,sw.ElapsedMilliseconds);
            //233168
        }
        static int SumDivisibleBy(int num, int target)
        {
            int p = target / num;
            return num * (p * (p + 1)) / 2;
        }
    }
}
