using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem004
{
    class Program
    {
        const int MAXNUM = 999;
        const int MINNUM = 100;
        static void Main(string[] args)
        {
            PalindromicChecker checker = new PalindromicChecker();
            int maxNum = 0;
            for (int i = MAXNUM; i >= MINNUM; i--)
            {
                for (int j = MAXNUM; j >= MINNUM; j--)
                {
                    int num = i * j;
                    if (checker.Check(num) && num > maxNum)
                        maxNum = num;
                }
            }
            Console.WriteLine(maxNum);
            Console.ReadLine();
        }
    }
}
