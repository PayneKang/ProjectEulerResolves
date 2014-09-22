using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem010
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeGenerator pg = new PrimeGenerator();
            bool[] primeArray = pg.CheckPrimeNumber(2000000);
            long sum = 0;
            for (int i = 0; i < primeArray.Length; i++)
            {
                if (primeArray[i])
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
