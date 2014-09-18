using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem006
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
            sum = sum * sum;
            Console.WriteLine(sum);
            for (int i = 1; i <= 100; i++)
            {
                sum = sum - i * i;
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
