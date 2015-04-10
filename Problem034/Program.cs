using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem034
{
    class Program
    {
        const int MAXVAL = 3265920;
        static void Main(string[] args)
        {
            int[] factorials = new int[10];
            factorials[0] = 1;
            for (int i = 1; i < factorials.Length; i++)
            {
                int num = 1;
                for (int j = 1; j <= i; j++)
                {
                    num *= j;
                }
                factorials[i] = num;
            }
            int result = 0;
            for (int i = 3; i <= MAXVAL; i++)
            {

                int[] numbers = NumberUtils.SplitNumber(i,1);
                int sum = 0;
                foreach (int num in numbers)
                {
                    sum += factorials[num];
                }
                if (sum == i)
                {
                    result += sum;
                }
            }
            Console.WriteLine(result);
        }
    }
}
