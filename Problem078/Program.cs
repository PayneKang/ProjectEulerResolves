using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Diagnostics;

namespace Problem078
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int> p = new List<int>();
            p.Add(1);
            int n = 1;
            while (true)
            {
                int i = 0;
                int penta = 1;
                p.Add(0);
                while (penta <= n)
                {
                    int sign = (i % 4 > 1) ? -1 : 1;
                    p[n] += sign * p[n - penta];
                    p[n] %= 1000000;
                    i++;
                    int j = (i % 2 == 0) ? i / 2 + 1 : -(i / 2 + 1);
                    penta = j * (3 * j - 1) / 2;
                }
                if (p[n] == 0)
                {
                    sw.Stop();
                    Console.WriteLine("Result is {0} time used {1}s{2}ms",n,sw.Elapsed.Seconds,sw.Elapsed.Milliseconds);
                    break;
                }
                n++;
            }

        }
    }
}
