using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem160
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(string.Format("f({0},1) = {1}", i, f(i, 1)));
                Console.WriteLine(string.Format("f({0},2) = {1}", i, f(i, 2)));
            }
        }

        static long n(long num)
        {
            long result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
                while (result % 10 == 0)
                    result /= 10;
            }
            return result;
        }
        static long f(long num,int digits)
        {
            long digitsNum = (long)Math.Pow(10, digits);
            long result = 1;
            for (long a = 1; a <= num; a++)
            {
                long tmp = a;
                while (tmp%10 == 0)
                {
                    tmp = tmp/10;
                }
                result *= tmp;
                while (result % 10 == 0)
                {
                    result = result/10;
                }
                if (result > digitsNum)
                {
                    result = result%digitsNum;
                }
            }
            return result;
        }
    }
}
