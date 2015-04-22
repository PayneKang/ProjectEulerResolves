using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem047
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorsGenerator fg = new FactorsGenerator();
            PrimeGenerator pg = new PrimeGenerator();
            Queue<long> consecutives = new Queue<long>();
            for (long num = 1000; ; num++)
            {
                List<long> factors = fg.GeneratorDistinctFactors(num);
                if (factors.Count != 4)
                    continue;
                bool allprime = true;
                foreach (long factor in factors)
                {
                    if (pg.CheckPrime((int)factor))
                        continue;
                    allprime = false;
                    break;
                }
                if (!allprime)
                    continue;
                consecutives.Enqueue(num);
                if (CheckConsecutive(consecutives,4))
                    break;
                if (consecutives.Count == 4)
                    consecutives.Dequeue();
            }
            Console.WriteLine(string.Format("Result is {0}", consecutives.Peek()));
        }
        static bool CheckConsecutive(Queue<long> que,int length)
        {
            if (que.Count != length)
                return false;
            long temp = 0;
            bool first = true;
            foreach (long num in que)
            {
                if (first)
                {
                    temp = num;
                    first = false;
                    continue;
                }
                if (num - temp != 1)
                    return false;
                temp = num;
            }
            return true;
        }
    }
}
