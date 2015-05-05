using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem049
{
    class Program
    {
        static PrimeGenerator pg = new PrimeGenerator();
        static List<int> primes;
        static void Main(string[] args)
        {
            primes = new List<int>();
            for (int i = 1000; i <= 9999; i++)
            {
                if (pg.CheckPrime(i,false))
                    primes.Add(i);
            }
            
            List<string> result = new List<string>();
            foreach (int prime in primes)
            {
                if (prime == 2969)
                {
                    Console.WriteLine();
                }
                int[] nums = BuildSeqNumbers(prime,true);
                if (nums.Count() < 3)
                    continue;
                List<int[]> tripleGroup = PermutationProvider.BuildPermutation<int>(nums, 3);
                foreach (int[] triple in tripleGroup)
                {
                    int[] temptpl = triple.OrderBy(x => x).ToArray();
                    if ((temptpl[2] - temptpl[1]) != (temptpl[1] - temptpl[0]))
                        continue;
                    string item = string.Format("{0}{1}{2}", temptpl[0], temptpl[1], temptpl[2]);
                    if (result.Contains(item))
                        continue;
                    result.Add(item);
                }
            }
        }
        static int[] BuildSeqNumbers(int num,bool checkPrime)
        {
            int[] basedigits = NumberUtils.SplitNumber((long)num, 1);
            List<int[]> digitsList = PermutationProvider.BuildPermutation<int>(basedigits, basedigits.Length);
            List<int> result = new List<int>();
            foreach (int[] digits in digitsList) {
                int tmp = 0;
                if (digits[0] == 0)
                    continue;
                foreach (int digit in digits)
                {
                    tmp *= 10;
                    tmp += digit;
                }
                if (result.Contains(tmp))
                    continue;
                if (!primes.Contains(tmp))
                    continue;
                result.Add(tmp);
            }
            return result.ToArray();
        }
    }
}
