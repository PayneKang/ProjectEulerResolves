using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem094
{
    class Program
    {
        static long max = 1000000000;
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long count = SolveB();
            sw.Stop();
            Console.WriteLine("Result is {0} ; timeused {1} ms",count,sw.Elapsed.TotalMilliseconds);
        }

        static long SolveB()
        {
            int[] m = new int[20];
            m[0] = -1;
            m[1] = 1;
            int a = 1;
            int i = 0;
            int sum = 0;
            for (i = 2; i < 20; i++)
            {
                m[i] = i%2 == 0 ? (m[i - 1] + m[i - 2]) : (2*m[i - 1] + m[i - 2]);
                a += 4*m[i]*m[i - 1];
                int b = (i % 2 == 0) ? (a + 1) : (a - 1);
                if (a <= 2)
                    continue;
                if (a + a + b > max)
                    return sum;
                sum += a + a + b;
            }
            return sum;
        }

        static long SolveA()
        {
            long twinSide = max / 3;
            long count = 0;
            for (long i = 2; i <= twinSide; i++)
            {
                if (CheckArea(i, i - 1))
                    count += 3 * i - 1;
                if (CheckArea(i, i + 1))
                    count += 3 * i + 1;
            }
            return count;

        }
        static bool CheckArea(long twinSide, long longSide)
        {
            if (longSide*longSide%4 != 0)
                return false;
            long squareHigh = twinSide*twinSide - longSide*longSide/4;
            long high = (long) (Math.Sqrt(squareHigh));
            if (high*high != squareHigh)
                return false;
            long doublearea = longSide*high;
            return doublearea%2 == 0;
        }
    }
}
