using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem076
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = WayToBuildSum(100, 99);
            Console.WriteLine(count);
        }
        static int WayToBuildSum(int sum, int nextMax)
        {
            if (sum == 0)
                return 1;
            if (nextMax == 0)
                return 0;
            int maxCoinCount = sum / nextMax;
            int count = 0;
            for (int i = maxCoinCount; i >= 0; i--)
            {
                count += WayToBuildSum(sum - nextMax * i, nextMax - 1);
            }
            return count;
        }
    }
}
