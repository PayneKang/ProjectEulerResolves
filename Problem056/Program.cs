using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;
using Kang.Algorithm.BaseLib;

namespace Problem056
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            for (int a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    BigInteger la = a;
                    BigInteger powresult = Pow(la, b);
                    long digitalSum = NumberUtils.SumDigits(powresult);
                    if (digitalSum > result)
                        result = digitalSum;
                    Console.WriteLine("{0} ^ {1} = {2} ; digital sum = {3}", a, b, powresult.ToString(), digitalSum);
                    
                }
            }
            Console.WriteLine("Result is {0}", result);
        }
        static BigInteger Pow(BigInteger num, int pow)
        {
            if (pow < 0)
                throw new ApplicationException("Pow can not be smaller than 0");
            if (pow == 0)
                return 1;
            if (pow == 1)
                return num;
            BigInteger result = num;
            int basenum = int.Parse(num.ToString());
            for (int i = 1; i < pow; i++)
            {
                result = result * basenum;
            }
            return result;
        }
    }
}
