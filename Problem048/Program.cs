using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem048
{
    class Program
    {
        static LargeNumberModel SeriesSum(int max)
        {
            LargeNumberModel result = new LargeNumberModel("0");
            for (int i = 1; i <= max; i++)
            {
                LargeNumberModel num = new LargeNumberModel(i.ToString());
                for (int j = 0; j < i - 1; j++)
                {
                    num = num * i;
                }
                result = result + num;
            }
            return result;
        }
        static void Main(string[] args)
        {
            LargeNumberModel num = SeriesSum(1000);
            Console.WriteLine(num.ToString().Substring(num.NumberLength - 10, 10));
        }
    }
}
