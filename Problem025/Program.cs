using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using Kang.Algorithm.BaseLib;
using System.Numerics;

namespace Problem025
{
    class Program
    {
        static void Main(string[] args)
        {

            FibonacciGenerator fg = new FibonacciGenerator();
            BigInteger num = fg.NextLargeNumber();
            BigInteger result;
            int index = 4;
            while (true)
            {
                index++;
                result = num = fg.NextLargeNumber();

                bool outOfEdge = true;
                for (int i = 0; i < 999; i++)
                {
                    num = num/10;
                    if (num == 0)
                    {
                        outOfEdge = false;
                        break;
                    }
                }
                if (outOfEdge)
                    break;
            }
            Console.WriteLine(result.ToString() + " index of " + index);

        }
    }
}
