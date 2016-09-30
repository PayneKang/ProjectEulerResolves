using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Kang.Algorithm.BaseLib;

namespace Problem075
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            long gcd = NumberUtils.GCD(50, 40);
            // a = m ^ 2 - n ^ 2;
            // b = 2 * m * n
            // c = m ^ 2 + n ^ 2
            // a ^ 2 + b ^ 2 = m ^ 4 + n ^ 4 + 2 * m ^ 2 * n ^ 2 = (m ^ 2 + n ^ 2) ^ 2 = c ^ 2
            long limit = 1500000;
            long[] triangles = new long[limit + 1];

            long result = 0;
            long mlimit = (long)Math.Sqrt(limit / 2);

            for (long m = 2; m < mlimit; m++)
            {
                for (long n = 1; n < m; n++)
                {
                    if (((n + m)%2) != 1)
                        continue;
                    if (NumberUtils.GCD(m, n) != 1)
                        continue;
                    long a = m*m + n*n;
                    long b = m*m - n*n;
                    long c = 2*m*n;
                    long p = a + b + c;
                    while (p <= limit)
                    {
                        triangles[p]++;
                        if (triangles[p] == 1) result++;
                        if (triangles[p] == 2) result--;
                        p += a + b + c;
                    }
                }
            }
            Console.WriteLine("Result is {0}", result);
        }
    }
}