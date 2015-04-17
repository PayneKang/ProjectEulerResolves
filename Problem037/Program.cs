using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem037
{
    class Program
    {
        static PrimeGenerator pg = new PrimeGenerator();
        static int[] seeds = new int[] { 1, 3, 7, 9 };
        static bool[] primes;
        static void Main(string[] args)
        {
            primes = pg.CheckPrimeNumber(5000000);
            List<int> result = new List<int>();
            int sum = 0;
            for (int i = 10; i<= 5000000 ; i++)
            {
                if (!Check(i))
                    continue;
                result.Add(i);
                sum += i;
            }
            Console.WriteLine(string.Format("Result is {0}", sum));
        }
        static bool Check(int num)
        {
            int temp = num;
            while (temp > 0)
            {
                if (!primes[temp])
                    return false;
                temp = temp / 10;
            }
            temp = num;
            int tem = 1;
            while (tem <= num) tem *= 10;
            while (temp > 0)
            {
                if (!primes[temp])
                    return false;
                temp = temp % tem;
                tem /= 10;
            }
            return true;
        }
    }
}
