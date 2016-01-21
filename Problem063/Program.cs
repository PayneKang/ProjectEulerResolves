using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem063
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 1; i <= 9; i++)
            {
                LargeNumberModel num = new LargeNumberModel(i.ToString());
                int pow = 1;
                while (true)
                {
                    if (num.NumberLength != pow)
                        break;
                    num = num * i;
                    count++;
                    pow++;
                }
            }
            Console.WriteLine(string.Format("result is {0}", count));
        }
    }
}
