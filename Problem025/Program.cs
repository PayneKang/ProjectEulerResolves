using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using Kang.Algorithm.BaseLib;

namespace Problem025
{
    class Program
    {
        static void Main(string[] args)
        {

            FibonacciGenerator fg = new FibonacciGenerator();
            LargeNumberModel num = fg.NextLargeNumber();
            int index = 4;
            while (num.NumberLength < 1000)
            {
                index++;
                num = fg.NextLargeNumber();
            }
            Console.WriteLine(num.ToString() + " index of " + index);

        }
    }
}
