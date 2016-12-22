// 参考 http://www.mathblog.dk/project-euler-137-fibonacci-golden-nuggets/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem137
{
    class Program
    {

        static FibonacciGenerator fg = new FibonacciGenerator();
        static void Main(string[] args)
        {
            long result = 0;
            for (int i = 1; i < 17; i++)
            {
                result = FindFibonacciGolden(i);
                Console.WriteLine("the {0}th golden is {1}",i,result);
            }
        }

        static long FindFibonacciGolden(int index)
        {
            return fg.GenerateFibonacci(2*index)*fg.GenerateFibonacci(2*index + 1);
        }
    }
}
