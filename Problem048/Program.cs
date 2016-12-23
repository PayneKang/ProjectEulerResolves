using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem048
{
    class Program
    {
        static BigInteger SeriesSum(int max)
        {
            BigInteger result = 0;
            for (int i = 1; i <= max; i++)
            {
                BigInteger num = i;
                for (int j = 0; j < i - 1; j++)
                {
                    num = num * i;
                }
                result = result + num;
            }
            return result;
        }
        static void Main(string[] args)
        {
            string num = SeriesSum(1000).ToString();
            Console.WriteLine(num.Substring(num.Length - 10, 10));
        }
    }
}
