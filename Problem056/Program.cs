using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem056
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            for (int a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    LargeNumberModel la = new LargeNumberModel(a.ToString());
                    LargeNumberModel powresult = Pow(la, b);
                    int digitalSum = powresult.Digits.Sum();
                    if (digitalSum > result)
                        result = digitalSum;
                    Console.WriteLine("{0} ^ {1} = {2} ; digital sum = {3}", a, b, powresult.ToString(), digitalSum);
                    
                }
            }
            Console.WriteLine("Result is {0}", result);
        }
        static LargeNumberModel Pow(LargeNumberModel num, int pow)
        {
            if (pow < 0)
                throw new ApplicationException("Pow can not be smaller than 0");
            if (pow == 0)
                return new LargeNumberModel("1");
            if (pow == 1)
                return num;
            LargeNumberModel result = new LargeNumberModel(num.ToString());
            int basenum = int.Parse(num.ToString());
            for (int i = 1; i < pow; i++)
            {
                result = result * basenum;
            }
            return result;
        }
    }
}
