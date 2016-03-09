using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem097
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = 2;
            for (int i = 1; i < 7830457; i++)
            {
                num = (num * 2) % 100000000000;
            }
            num = num * 28433 + 1;
            string result = num.ToString().Substring(num.ToString().Length - 10);
        }
    }
}
