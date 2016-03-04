using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem075
{
    class Program
    {
        const long MAXTOTAL = 1500000;
        static Dictionary<long, List<long[]>> tri = new Dictionary<long, List<long[]>>();
        static void AddToTri(long total, long[] val)
        {
            foreach (long[] tmp in tri[total])
            {
                if (tmp.OrderBy(x => x).First() == val.OrderBy(x => x).First())
                    return;
            }
            tri[total].Add(val);
        }
        static void Main(string[] args)
        {
            int max = (int)((float)MAXTOTAL / (2 + Math.Sqrt(2)));
            for (int a = 3; a <= max; a += 2)
            {
                long n = (a - 1) / 2;
                long b = 2 * n * (n + 1);
                long c = b + 1;
                long total = a + b + c;
                if (total > MAXTOTAL)
                    continue;
                if (!tri.ContainsKey(total))
                {
                    tri.Add(total, new List<long[]>());
                }
                AddToTri(total, new long[] { a, b, c });
                int i = 1;
                while (true)
                {
                    i++;
                    long tTotal = total * i;
                    if (tTotal > MAXTOTAL)
                    {
                        break;
                    }
                    long ta = a * i;
                    long tb = b * i;
                    long tc = c * i;
                    if (!tri.ContainsKey(tTotal))
                    {
                        tri.Add(tTotal, new List<long[]>());
                    }
                    AddToTri(tTotal, new long[] { ta, tb, tc });
                }
            }
            for (int a = 6; a <= max; a += 2)
            {
                long n = a / 2;
                long b = n * n - 1;
                long c = n * n + 1;
                long total = a + b + c;
                if (total > MAXTOTAL)
                    continue;
                if (!tri.ContainsKey(total))
                {
                    tri.Add(total, new List<long[]>());
                }
                AddToTri(total, new long[] { a, b, c });
                int i = 1;
                while (true)
                {
                    i++;
                    long tTotal = total * i;
                    if (tTotal > MAXTOTAL)
                    {
                        break;
                    }
                    long ta = a * i;
                    long tb = b * i;
                    long tc = c * i;
                    if (!tri.ContainsKey(tTotal))
                    {
                        tri.Add(tTotal, new List<long[]>());
                    }
                    AddToTri(tTotal, new long[] { ta, tb, tc });
                }
            }
            List<long> totals = tri.Keys.ToArray().OrderBy(x => x).ToList();
            int count = 0;
            foreach (long t in totals)
            {
                if (tri[t].Count == 1)
                {
                    count++;
                }
                //Console.WriteLine("total length is {0}", t);
                //foreach (long[] trig in tri[t])
                //{
                //    Console.WriteLine("\t a = {0} , b = {1} , c = {2}", trig[0], trig[1], trig[2]);
                //}
            }
            Console.WriteLine("Result is {0}", count);
        }
    }
}
