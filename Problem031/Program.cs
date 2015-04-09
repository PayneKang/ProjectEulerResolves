using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem031
{
    class Program
    {
        static int[] Coins = new int[] { 1, 2, 5,10,20,50,100,200};
        static void Main(string[] args)
        {
            int count = WayToBuildSum(200, 7);
            Console.WriteLine(count);
        }
        static int WayToBuildSum(int sum, int coinIndex)
        {
            if (sum == 0)
                return 1;
            if (coinIndex < 0)
                return 0;
            int maxCoin = Coins[coinIndex];
            int maxCoinCount = sum / maxCoin;
            int count = 0;
            for (int i = maxCoinCount; i >= 0; i--)
            {
                count += WayToBuildSum(sum - maxCoin * i,coinIndex - 1);
            }
            return count;
        }
    }
}
