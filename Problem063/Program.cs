using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem063
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 1; i <= 9; i++)
            {
                BigInteger num = i;
                int pow = 1;
                while (true)
                {
                    if (num.ToString().Length != pow)
                        break;
                    num = num * i;
                    count++;
                    pow++;
                }
            }
            Console.WriteLine(string.Format("result is {0}", count));
        }
    }
}
