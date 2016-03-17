using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem323
{
    class Program
    {
        const UInt32 TERMINAL = 0xFFFFFFFF;
        static void Main(string[] args)
        {
            double sum = 0f;
            for (int n = 1; ; n++)
            {
                double p = cdf(n) - cdf(n - 1);
                if(p < 0.000000000000000000001){
                    break;
                }
                sum += n * p;
            }
            Console.WriteLine(string.Format("{0}",sum.ToString("%.10f")));

        }
        static double cdf(int n)
        {
            if (n >= 0)
                return Math.Pow(1 - Math.Pow(2, -n), 32);
            else
                return 0;
        }
    }
}
