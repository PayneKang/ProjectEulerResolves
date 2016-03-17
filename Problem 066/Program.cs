using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem_066
{
    class Program
    {
        const int MAX_LIMIT = 100000;
        static LargeNumberFractionModel CalculateNextFraction(int seed, LargeNumberFractionModel onePre, LargeNumberFractionModel twoPre)
        {
            BigInteger divisor = onePre.Divisor * seed + twoPre.Divisor;
            BigInteger dividend = onePre.Dividend * seed + twoPre.Dividend;
            return new LargeNumberFractionModel() { Divisor = divisor, Dividend = dividend };
        }
        static int[] primes;

        static void Main(string[] args)
        {
            int minNum = -1;
            BigInteger maxX = BigInteger.Zero;
            for(int i = 2; i <= 1000; i++){
                if (IsSquare(i))
                    continue;
                BigInteger x = CalculateSmallestX(i);
                if( x <= maxX)
                    continue;
                minNum = i;
                maxX = x;
            }
        }

        static BigInteger CalculateSmallestX(int num)
        {
            List<List<BigInteger>> contFrac = sqrtToContinuedFraction(num);

            List<BigInteger> temp = new List<BigInteger>();
        }

        static bool IsSquare(int num)
        {
            int sqrt = (int)Math.Sqrt(num);
            return sqrt * sqrt == num;
        }

        static Complex GetSquare(Complex num)
        {
            Complex sqrt = System.Numerics.Complex.Sqrt(num);
            if (sqrt * sqrt == num)
            {
                return sqrt;
            }
            return 0;
        }
    }
}
