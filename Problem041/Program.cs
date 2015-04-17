using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem041
{
    class Program
    {
        static bool[] prime;
        static void Main(string[] args)
        {
            prime = new PrimeGenerator().CheckPrimeNumber(7654321);
            int result = 0;
            for (int i = 7; i > 0; i--){
            
                int[] tempSeeds = new int[i];
                for (int j = i; j > 0; j--)
                {
                    tempSeeds[i - j] = j;
                }
                List<int[]> digitsList = PermutationProvider.BuildPermutation<int>(tempSeeds, i);
                foreach (int[] digits in digitsList)
                {
                    int num = 0;
                    for (int k = 0; k < digits.Length; k ++ )
                    {
                        num += digits[k] * (int)Math.Pow(10,k);
                    }
                    if (!prime[num])
                        continue;
                    result = num;
                    break;
                }
                if (result > 0)
                    break;
            }
            Console.WriteLine(string.Format("Result is {0}", result));
        }
    }
}
