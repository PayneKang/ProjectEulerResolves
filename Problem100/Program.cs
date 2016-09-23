using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem100
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            long totalCount = 0;
            for (long n = 2; ; n++)
            {
                double a = Math.Sqrt(n) * Math.Sqrt(n - 1) *Math.Sqrt(0.5d);
                long num = (long)a;
                
                Console.WriteLine(((double)num * ((double)num + 1) )/ ((double)n * ((double)n-1)));
                BigInteger ba = num;
                BigInteger bn = n;
                if ((bn * (bn - 1)) == 2 * (ba * (ba + 1)))
                {
                    result = num + 1;
                    totalCount = n;
                    
                }
            }
        }
    }
}
