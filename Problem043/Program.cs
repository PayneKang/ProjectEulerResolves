using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem043
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] seeds = new int[]{0,1,2,3,4,5,6,7,8,9};
            List<int[]> result = PermutationProvider.BuildPermutation<int>(seeds, 10);
            long total = 0;
            foreach (int[] digits in result)
            {
                if (digits[0] == 0)
                    continue;
                // 2 - 4
                if (digits[3] % 2 != 0)
                    continue;
                // 3 - 5
                if ((digits[2] + digits[3] + digits[4]) % 3 != 0)
                    continue;
                // 4 - 6
                if (digits[5] != 0 && digits[5] != 5)
                    continue;
                // 5 - 7
                if (BuildNum(digits[4], digits[5], digits[6]) % 7 != 0)
                    continue;
                // 6 - 8
                if (BuildNum(digits[5], digits[6], digits[7]) % 11 != 0)
                    continue;
                // 7 - 9
                if (BuildNum(digits[6], digits[7], digits[8]) % 13 != 0)
                    continue;
                // 8 - 10
                if (BuildNum(digits[7], digits[8], digits[9]) % 17 != 0)
                    continue;
                total += BuildLong(digits);
            }
            Console.WriteLine(string.Format("Result is {0}", result));
        }
        static long BuildLong(int[] digits)
        {
            long result = 0;
            foreach (int dig in digits)
            {
                result *= 10;
                result += dig;
            }
            return result;
        }
        static int BuildNum(int digit1, int digit2, int digit3)
        {
            return digit1 * 100 + digit2 * 10 + digit3;
        }
    }
}
