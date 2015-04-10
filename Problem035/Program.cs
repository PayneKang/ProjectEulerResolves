using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem035
{
    class Program
    {
        static PrimeGenerator pg = new PrimeGenerator();
        static bool[] primeMark;
        const int MAX = 1000000;
        static void Main(string[] args)
        {
            primeMark = pg.CheckPrimeNumber(MAX);
            int count = 0;
            for (int i = 2; i < MAX; i++)
            {
                if (CheckCircularPrime(i))
                {
                    count++;
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine(string.Format("Primes count below {0} is {1}", MAX, count));
        }
        static bool CheckCircularPrime(int num)
        {
            int[] digits = NumberUtils.SplitNumber(num,1);
            List<int[]> numDigits = RotationProvider.BuildRotations<int>(digits);
            foreach (int[] newDigits in numDigits)
            {
                int num2 = 0;
                for (int i = 0; i < newDigits.Length; i++)
                {
                    num2 += newDigits[i] * (int)Math.Pow(10, i);
                }
                if (!primeMark[num2])
                    return false;

            }
            return true;
        }
    }
}
