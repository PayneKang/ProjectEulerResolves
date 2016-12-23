using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem055
{
    class Program
    {
        static void Main(string[] args)
        {
            int lychrelCount = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (!CanGetPalindromicIn50Cycles(i))
                    lychrelCount++;
            }
            Console.WriteLine(string.Format("Result is {0}", lychrelCount));
        }
        static bool CanGetPalindromicIn50Cycles(BigInteger number)
        {
            BigInteger temp = BigInteger.Parse(number.ToString());
            for (int i = 0; i < 50; i++)
            {
                BigInteger reverse = ReverseNumber(temp);
                BigInteger sum = temp + reverse;
                if (CheckPalindromic(sum))
                    return true;
                temp = sum;
            }
            return false;
        }
        static bool CheckPalindromic(BigInteger number)
        {
            string reverse = ReverseNumber(number).ToString();
            if (string.Equals(number.ToString(),reverse))
                return true;
            return false;
        }
        static BigInteger ReverseNumber(BigInteger number)
        {
            BigInteger temp = number;
            BigInteger result = 0;
            while (temp > 0)
            {
                result *= 10;
                result += temp % 10;
                temp = temp / 10;
            }
            return result;
        }
    }
}
