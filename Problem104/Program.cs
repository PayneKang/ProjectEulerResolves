using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem104
{
    class Program
    {
        static void Main(string[] args)
        {
            LargeNumberModel a = new LargeNumberModel("1");
            LargeNumberModel b = new LargeNumberModel("1");
            int i = 3;
            while (true)
            {
                LargeNumberModel temp = a;
                a = b;
                b = temp + b;
                Console.WriteLine(b);
                int startIndex = 0;
                int length = 9;
                int digitLen = b.Digits.Length;
                if (digitLen > 9)
                {
                    startIndex = b.Digits.Length - 9;
                }
                else
                {
                    length = digitLen;
                }
                IEnumerable<int> lastNineDigits = b.Digits.Skip(startIndex).Take(length);
                IEnumerable<int> firstNineDigits = b.Digits.Take(length);
                if (firstNineDigits.Where(x => x != 0).Distinct().Count() == 9 && lastNineDigits.Where(x => x != 0).Distinct().Count() == 9)
                {
                    break;
                }
                i++;
            }
        }
    }
}
