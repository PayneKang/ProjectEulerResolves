using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem001
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int[] multiples = new int[] {3,5};

            bool[] mark = new bool[1000];
            foreach (int multiple in multiples)
            {
                int n = multiple;
                while (n < 1000)
                {
                    mark[n] = true;
                    n += multiple;
                }
            }
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (mark[i])
                    sum += i;
            }

            sw.Stop();
            Console.WriteLine("Result is {0} , timeused {1}ms",sum,sw.ElapsedMilliseconds);
            //233168
            #region 旧方法

            //int sum = 0;
            //for (int i = 3; i < 1000; i++)
            //{
            //    MultiplesChecker checker = new MultiplesChecker(i, multiples);
            //    if (checker.Check())
            //    {
            //        sum += i;
            //    }
            //}
            //Console.WriteLine(sum);

            #endregion
        }
    }
}
