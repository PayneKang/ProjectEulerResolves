using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Kang.Algorithm.BaseLib
{
    public class SquareRootRepeatIndefiniteCalculator
    {
        public class SqrtResultModel
        {
            public int IntegerNumber { get; set; }
            public List<FormulaItem> Sequrence { get; set; }
        }
        public class FormulaItem
        {
            public int IntegerNumber { get; set; }
            public int Subtractor { get; set; }
            public int Denominator { get; set; }
            public override bool Equals(object obj)
            {

                FormulaItem item = (FormulaItem)obj;
                return (item.IntegerNumber == this.IntegerNumber && item.Subtractor == this.Subtractor && item.Denominator == this.Denominator);
            }
            public override string ToString()
            {
                return string.Format("I{0}_S{1}_D{2}", this.IntegerNumber, this.Subtractor, this.Denominator);
            }
        }
        public static int GetSquare(int num)
        {
            int sqrt = (int)Math.Sqrt(num);
            if (sqrt * sqrt == num)
            {
                return sqrt;
            }
            return -1;
        }
        public static SqrtResultModel FindNumSqrtInteger(int num)
        {
            int integerNumber = (int)(Math.Sqrt(num));
            if (integerNumber * integerNumber == num)
            {
                return null;
            };
            SqrtResultModel result = new SqrtResultModel()
            {
                IntegerNumber = integerNumber,
                Sequrence = new List<FormulaItem>()
            };
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int nextIntegerNumber = integerNumber;
            int temp = num;
            int tempDenominator = 1;
            while (true)
            {
                int nextDenominator = temp - nextIntegerNumber * nextIntegerNumber;
                nextDenominator /= tempDenominator;
                int tempIntegerNum = nextIntegerNumber;
                nextIntegerNumber = (int)((Math.Sqrt(temp) + nextIntegerNumber) / nextDenominator);
                int nextSubNum = nextIntegerNumber * nextDenominator - tempIntegerNum;

                FormulaItem fi = new FormulaItem()
                {
                    Denominator = nextDenominator,
                    IntegerNumber = nextIntegerNumber,
                    Subtractor = nextSubNum
                };
                if (dic.ContainsKey(fi.ToString()))
                    break;
                dic.Add(fi.ToString(), null);
                result.Sequrence.Add(fi);
                nextIntegerNumber = nextSubNum;
                tempDenominator = nextDenominator;
            }
            return result;
        }
    }
}
