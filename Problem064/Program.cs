using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using Kang.Algorithm.BaseLib;

namespace Problem064
{
    class Program
    {
        static int MAX = 10000;
        static void Main(string[] args)
        {
            int result = 0;
            for (int i = 2; i <= MAX; i++)
            {
                SquareRootRepeatIndefiniteCalculator.SqrtResultModel rlt = SquareRootRepeatIndefiniteCalculator.FindNumSqrtInteger(i);
                if (null == rlt)
                    continue;
                if (rlt.Sequrence.Count % 2 == 0)
                    continue;
                result++;
            }
            Console.WriteLine(string.Format("result is {0}", result));
        }
    }
}
