using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem001
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] multiples = new int[] {3,5};
            int sum = 0;
            for(int i = 3; i < 1000; i ++){
                MultiplesChecker checker = new MultiplesChecker(i, multiples);
                if (checker.Check())
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
