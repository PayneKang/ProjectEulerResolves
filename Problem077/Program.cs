using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem077
{
    class Program
    {
        static int[] Primes;

        static void Main(string[] args)
        {
            Primes = new PrimeGenerator().GetPrimesBelowOneMillion();
            int n = 10;
            while (true)
            {
                int index = 0;                
                for(int i = 0; i < Primes.Length; i++){
                    if (Primes[i] >= n)
                        break;
                    index = i;
                }
                int count = WayToBuildSum(n, index);
                if (count > 5000)
                {
                    Console.WriteLine(n);
                    return;
                }
                n++;
            }
        }
        static int WayToBuildSum(int sum, int coinIndex)
        {
            if (sum == 0)
                return 1;
            if (coinIndex < 0)
                return 0;
            int maxCoin = Primes[coinIndex];
            int maxCoinCount = sum / maxCoin;
            int count = 0;
            for (int i = maxCoinCount; i >= 0; i--)
            {
                count += WayToBuildSum(sum - maxCoin * i, coinIndex - 1);
            }
            return count;
        }
    }
}
