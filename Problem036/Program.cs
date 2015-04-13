using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem036
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            for (int i = 1; i < 1000000; i++)
            {
                string num = i.ToString();
                string binnum = Convert.ToString(i, 2);
                if (!CheckPalindromic(num))
                    continue;
                if (!CheckPalindromic(binnum))
                    continue;
                result += i;
            }
            Console.WriteLine(string.Format("result is {0}", result));
        }
        static bool CheckPalindromic(string str)
        {
            char[] strArray = str.ToCharArray();
            int len = strArray.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (strArray[i] != strArray[len - i - 1])
                    return false;
            }
            return true;
        }
    }
}
