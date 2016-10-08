using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem104
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger fn1 = 1;
            BigInteger fn2 = 1;
            BigInteger fn;
            BigInteger tailcut = 1000000000;
            int n = 2;
            while (true)
            {
                n++;
                fn = fn1 + fn2;
                long tail = (long)(fn % tailcut);
                fn1 = fn2;
                fn2 = fn;
                if (!IsPandigital(tail))
                    continue;
                int digits = 1 + (int) BigInteger.Log10(fn);
                if(digits <= 9)
                    continue;
                long head = (long) (fn/BigInteger.Pow(10, digits - 9));
                if (IsPandigital(head))
                    break;
            }
            Console.WriteLine("Result is {0}",n);
        }

        static bool IsPandigital(long num)
        {
            List<int> nums = new List<int>();
            while (num > 0)
            {
                nums.Add((int)(num % 10));
                num = num/10;
            }
            return nums.Where(x => x != 0).Distinct().Count() == 9;
        }
    }
}
