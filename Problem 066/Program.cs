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
        static LargeNumberFractionModel CalculateNextFraction(int seed, LargeNumberFractionModel onePre, LargeNumberFractionModel twoPre)
        {
            BigInteger divisor = onePre.Divisor * seed + twoPre.Divisor;
            BigInteger dividend = onePre.Dividend * seed + twoPre.Dividend;
            return new LargeNumberFractionModel() { Divisor = divisor, Dividend = dividend };
        }
        static void Main(string[] args)
        {
            LargeNumberFractionModel rlt = Calculate(661);
            //LargeNumberFractionModel temp = Calculate(271);
            //BigInteger max = 0;
            //int maxI = 0;
            //for (int i = 2; i <= 1000; i++)
            //{
            //    LargeNumberFractionModel rlt = Calculate(i);
            //    if (rlt == null)
            //        continue;
            //    if (rlt.Dividend > max)
            //    {
            //        max = rlt.Dividend;
            //        maxI = i;
            //    }
            //}
            //Complex maxX = 0;
            //for (int i = 2; i <= 7; i++)
            //{
            //    Complex x = CalculateX(i);
            //    if (x.Magnitude > maxX.Magnitude)
            //    {
            //        maxX = x;
            //    }
            //}
            //Console.WriteLine(string.Format("result is {0}", maxX));
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
        static long GetSquare(long num)
        {
            long sqrt = (long)Math.Sqrt(num);
            if (sqrt * sqrt == num)
            {
                return sqrt;
            }
            return 0;
        }
        static Complex CalculateX(long D)
        {
            
            if (GetSquare(D) > 0)
            {
                return -1;
            }
            long y = 1;
            while (true)
            {
                Complex x = 1 + D * y * y;
                Complex rlt = GetSquare(x);
                if (rlt.Equals(Complex.Zero))
                {
                    Console.WriteLine(string.Format(" D = {2},x = {0}, y = {1}", rlt.ToString().PadRight(8), y.ToString().PadRight(8), D.ToString().PadRight(4)));
                    return rlt;
                }
                y++;
            }
        }
        static LargeNumberFractionModel Calculate(int seed)
        {
            SquareRootRepeatIndefiniteCalculator.SqrtResultModel rlt = SquareRootRepeatIndefiniteCalculator.FindNumSqrtInteger(seed);
            if (rlt == null)
            {
                return null;
            }
            List<int> lst = new List<int>();
            lst.Add(rlt.IntegerNumber);
            for (int i = 0; i < rlt.Sequrence.Count; i++)
            {
                lst.Add(rlt.Sequrence[i].IntegerNumber);
            }
            LargeNumberFractionModel onePre = new LargeNumberFractionModel() { Dividend = 1, Divisor =0 };
            LargeNumberFractionModel twoPre = new LargeNumberFractionModel() { Dividend = 0, Divisor =1 };
            LargeNumberFractionModel current = CalculateNextFraction(lst[0], onePre, twoPre);
            int index = 1;
            while (true)
            {
                twoPre = onePre;
                onePre = current;
                current = CalculateNextFraction(lst[index], onePre, twoPre);
                if ((current.Dividend * current.Dividend) == ((current.Divisor * current.Divisor) * seed + 1))
                {
                    Console.WriteLine("{0}^2 - {1}*{2}^2 = 1", current.Dividend, seed, current.Divisor);
                    return current;
                }
                index++;
                if (index >= lst.Count)
                {
                    index = 1;
                }
            }
        }
    }
}
