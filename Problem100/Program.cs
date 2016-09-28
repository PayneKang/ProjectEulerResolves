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
            long blueCount = 15;
            long totalCount = 21;
            long target = 1000000000000;

            while (totalCount < target)
            {
                long tempBlue = 3*blueCount + 2*totalCount - 2;
                long tempTotal = 4*blueCount + 3*totalCount - 3;
                blueCount = tempBlue;
                totalCount = tempTotal;
            }
            Console.WriteLine("Result is {0}", blueCount);
        }
    }
}
