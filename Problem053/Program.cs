using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem053
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int seedCount = 1; seedCount <= 100; seedCount++)
            {
                for (int length = 1; length <= seedCount; length++)
                {
                    bool outofmaxval = false;
                    long tmpCount = CombinationProvider.CountCombination(seedCount, length, 10000000, out outofmaxval);
                    if (tmpCount < 0)
                    {
                        Console.WriteLine();
                    }
                    if (tmpCount > 1000000)
                    {
                        count++;
                    }
                }
            }
        }
    }
}
