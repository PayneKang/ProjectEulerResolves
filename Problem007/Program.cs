using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem007
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeGenerator target = new PrimeGenerator();
            int i = 3;
            int index = 1;
            while (true)
            {
                if (target.CheckPrime(i))
                {
                    index++;
                }
                if (index == 10001)
                {
                    Console.WriteLine(i);
                    break;
                }
                i += 2;
            }
            Console.ReadLine();
        }
    }
}
