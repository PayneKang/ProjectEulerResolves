using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem110
{
    class Program
    {
        // n ^ 2 = i * j;
        static void Main(string[] args)
        {
            for (int n = 2; ; n++)
            {
                int count = CountSolution(n);
                if (count > 4000000)
                {
                    Console.WriteLine("Result is {0}", n);
                    break;
                }
            }
        }
        static int CountSolution(int num)
        {
            int count = 1;
            int temp = num;
            for (int i = 2; i <= (int)Math.Sqrt(num); i++)
            {
                if (temp % i != 0)
                    continue;
                
                int tempCount = 0;
                while (temp % i == 0)
                {
                    tempCount++;
                    temp /= i;
                }
                count *= (tempCount * 2 + 1);
            }
            if (temp != 1)
                count *= 3;
            return (count + 1) / 2;
        }
    }
}
