using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Kang.Algorithm.BaseLib;
using Kang.Algorithm.BaseLib.Models;

namespace Problem080
{
    class Program
    {
        static int MAXLEN = 100;
        static void Main(string[] args)
        {
            LargeNumberModel ln = new LargeNumberModel("123123895345345");
            //int result = 0;
            //for (int i = 2; i <= MAXLEN; i++)
            //{
            //    SquareRootRepeatIndefiniteCalculator.SqrtResultModel rlt = SquareRootRepeatIndefiniteCalculator.FindNumSqrtInteger(i);
            //    if (null == rlt)
            //        continue;
            //    int[] seeds = buildSequrence(rlt.Sequrence);
            //    LargeNumberModel[] frac = BuildFractionResult((int)Math.Sqrt(i), seeds, 0);
            //    //List<int> calRlt = CalculateFrac(frac);
            //    //int numSum = calRlt.Sum();
            //}
            //Console.WriteLine(string.Format("result is {0}", result));
        }

        //static List<int> CalculateFrac(LargeNumberModel[] frac)
        //{
        //    List<int> result = new List<int>();
        //    // 分子
        //    LargeNumberModel dividend = frac[0];
        //    // 分亩
        //    LargeNumberModel divisor = frac[1];
        //    // 去除整数部分；
        //    BigInteger intPart = 0;
        //    if (dividend > divisor)
        //    {
        //        intPart++;
        //        dividend = dividend - divisor;
        //    }
        //    for (int i = 0; i < MAXLEN; i++)
        //    {
        //        int rlt = (int)((intPart * 10) /divisor);
        //        intPart = intPart * 10 % divisor;
        //        result.Add(rlt);
        //    }
        //    return result;
        //}


        static LargeNumberModel[] BuildFractionResult(int baseNum, int[] seeds, int len)
        {
            int index = len % seeds.Length;
            if (len == MAXLEN)
            {
                if (len == 0)
                    return new LargeNumberModel[] { new LargeNumberModel(baseNum.ToString()), new LargeNumberModel("1") };
                return new LargeNumberModel[] { new LargeNumberModel(seeds[index - 1].ToString()), new LargeNumberModel("1") };
            }
            int nextBase = seeds[index];
            len++;
            LargeNumberModel[] chdFrac = BuildFractionResult(nextBase, seeds, len);
            LargeNumberModel dividend = chdFrac[0];
            LargeNumberModel divisor = dividend * baseNum + chdFrac[1];
            return new LargeNumberModel[] { divisor, dividend };
        }

        static int[] buildSequrence(List<SquareRootRepeatIndefiniteCalculator.FormulaItem> lst)
        {
            int[] rlt = new int[lst.Count];
            for (int i = 0; i < lst.Count; i++)
            {
                rlt[i] = lst[i].IntegerNumber;
            }
            return rlt;
        }
    }
}
