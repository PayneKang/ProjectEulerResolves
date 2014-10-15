using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem020
{
    class Program
    {
        static void Main(string[] args)
        {
            LargeNumberModel num = new LargeNumberModel("1");
            for (int i = 2; i <= 100; i++)
            {
                num = num * i;
            }
            int result = 0;
            foreach (int i in num.Digits)
            {
                result += i;
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
