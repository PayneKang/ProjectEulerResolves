using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem138
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;

            long x = 0;
            long y = -1;

            for (int i = 0; i < 12; i++)
            {
                long xnew = -9 * x + -4 * y + 4;
                long ynew = -20 * x + -9 * y + 8;

                x = xnew;
                y = ynew;

                result += Math.Abs(y);
            }
            Console.WriteLine("Result is {0}", result);
        }

    }
}
