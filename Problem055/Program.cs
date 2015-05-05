using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem055
{
    class Program
    {
        static void Main(string[] args)
        {
            int lychrelCount = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (!CanGetPalindromicIn50Cycles(new LargeNumberModel(i.ToString())))
                    lychrelCount++;
            }
            Console.WriteLine(string.Format("Result is {0}", lychrelCount));
        }
        static bool CanGetPalindromicIn50Cycles(LargeNumberModel number)
        {
            LargeNumberModel temp = new LargeNumberModel(number.ToString());
            for (int i = 0; i < 50; i++)
            {
                LargeNumberModel reverse = ReverseNumber(temp);
                LargeNumberModel sum = temp + reverse;
                if (CheckPalindromic(sum))
                    return true;
                temp = sum;
            }
            return false;
        }
        static bool CheckPalindromic(LargeNumberModel number)
        {
            string reverse = ReverseNumber(number).ToString();
            if (string.Equals(number.ToString(),reverse))
                return true;
            return false;
        }
        static LargeNumberModel ReverseNumber( LargeNumberModel number)
        {
            LargeNumberModel result = new LargeNumberModel();
            result.Digits = number.Digits.Reverse().ToArray();
            return result;
        }
    }
}
