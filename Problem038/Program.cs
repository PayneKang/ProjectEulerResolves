using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem038
{
    class Program
    {
        static bool[] pandigitals;
        static long MAX = 987654322;
        static void Main(string[] args)
        {
            BuildNumbersToCheck();
            long maxNum = 0;
            long test = BuildProductPandigital(192, 3, MAX);
            long test2 = BuildProductPandigital(9, 5, MAX);
            int maxI = 0;
            int maxJ = 0;
            for(int i = 10000; i >= 1; i--)
            {
                int len = GetNumLength(i);
                int terminalJ = 9 / len;
                for (int j = 9; j>=2 ; j--)
                {
                    if (i == 192 && j == 3)
                    {
                        Console.WriteLine();
                    }
                    long tempResult = BuildProductPandigital(i, j, MAX);
                    if (tempResult < 123456789)
                        continue;
                    if (tempResult > 987654321)
                        continue;
                    if (!pandigitals[tempResult])
                        continue;
                    if (maxNum < tempResult)
                        {
                            maxNum = tempResult;
                            maxI = i;
                            maxJ = j;
                        }
                    
                }
            }
            Console.WriteLine(string.Format("Result is {0}",maxNum))
        }
        static void BuildNumbersToCheck()
        {
            int[] seeds = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            List<int[]> digitsList = PermutationProvider.BuildPermutation<int>(seeds, 9);
            pandigitals = new bool[1000000000];
            foreach (int[] digits in digitsList)
            {
                long temp = 0;
                for (int i = 8; i >=0; i--)
                {
                    temp = temp * 10;
                    temp += digits[i];
                }
                pandigitals[temp] = true;
            }
        }
        static long BuildProductPandigital(int a, int b, long maxValue)
        {
            long result = 0;
            for (int i = 1; i <= b; i++)
            {
                long temp = a * i;
                int len = GetNumLength(temp);
                for (int j = 0; j < len; j++)
                {
                    result *= 10;
                }
                result += temp;
                if (result > maxValue)
                    return maxValue;
            }
            return result;
        }
        static int GetNumLength(long num)
        {
            int len = 0;
            while (num > 0)
            {
                len++;
                num /= 10;
            }
            return len;
        }
        static bool Check(long num)
        {
            long temp = num % 10;
            List<long> digits = new List<long>();
            while (temp > 0)
            {
                if (digits.Contains(temp))
                    return false;
                num /= 10;
                temp = num % 10;
            }
            return true;
        }
    }
}
