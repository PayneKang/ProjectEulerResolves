using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem12
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleNumberGenerator tng = new TriangleNumberGenerator();
            FactorsGenerator fg = new FactorsGenerator();
            int maxDivisorCount = 0;
            while (true)
            {
                int factors = fg.GeneratorDistinctDivisorCount(tng.Next());
                if (factors > maxDivisorCount)
                    maxDivisorCount = factors;
                Console.Out.WriteLine(string.Format("number:{0} - count:{1} - maxcount: {2}", tng.CurrentTriangle, factors, maxDivisorCount));
                if (factors <= 500)
                    continue;
                Debug.Write(tng.CurrentTriangle + "\r\n");
                Console.Out.Write(tng.CurrentTriangle + ":");
                Console.Write("\r\n");
                break;
            }
            Console.Read();
        }
    }
}
