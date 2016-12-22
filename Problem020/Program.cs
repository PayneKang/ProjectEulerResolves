using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem020
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num = 1;
            for (int i = 2; i <= 100; i++)
            {
                num = num * i;
            }
            BigInteger result = 0;
            while (num > 0)
            {
                result += num % 10;
                num = num / 10;
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
