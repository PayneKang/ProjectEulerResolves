using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem002
{
    class Program
    {
        static void Main(string[] args)
        {
            FibonacciGenerator generator = new FibonacciGenerator();
            int currentNum = 3;
            int sum = 2;
            while(currentNum < 4000000)
            {
                currentNum = generator.Next();
                Console.Write(currentNum + " ,");
                if (currentNum % 2 == 0)
                    sum += currentNum;
            }
            Console.Write("\r\nsum = " + sum);
            Console.ReadLine();
        }
    }
}
