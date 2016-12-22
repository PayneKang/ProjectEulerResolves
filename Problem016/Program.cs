using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem016
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num = 2; // 11930336
            for (int i = 1; i < 1000; i++ )
                num = num * 2;
            Console.WriteLine(num);
            string result = num.ToString();
            int sum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                sum += int.Parse(result.Substring(i, 1));
            }
            Console.WriteLine(string.Format("sum:{0}",sum));
            Console.Read();
        }
    }
}
