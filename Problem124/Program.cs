using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem124
{
    class Program
    {
        const int Max = 100000;
        static int[][] nums;
        static void Main(string[] args)
        {
            nums = new int[Max + 1][];
            for (int i = 0; i <= Max; i++)
            {
                nums[i] = new int[] { i, 1, i };
            }
            int[] primes = new PrimeGenerator().GetPrimesBelowOneMillion();
            for (int i = 0; i <= primes.Length; i++)
            {
                int prime = primes[i];
                if (prime > Max)
                    break;
                int start = prime;
                while (start <= Max)
                {
                    nums[start][1] *= prime;
                    while (nums[start][0] % prime == 0)
                    {
                        nums[start][0] = nums[start][0] / prime;
                    }
                    start += prime;
                }
            }
            var ordered = nums.OrderBy(x => x[1]);
            int result = ordered.Skip(10000).Take(1).FirstOrDefault()[2];
            Console.WriteLine("Result is {0}", result);
            Console.ReadLine();
        }
        
    }
}
