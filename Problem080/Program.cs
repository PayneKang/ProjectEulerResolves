using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Kang.Algorithm.BaseLib;
using Kang.Algorithm.BaseLib.Models;
using System.Diagnostics;

namespace Problem080
{
    public class SqrtResult
    {
        public int IntergerValue { get; set; }
        public List<int> DecimalDigits { get; set; }
        public override string ToString()
        {
            return string.Format("{0}.{1}", this.IntergerValue, string.Join("", this.DecimalDigits));
        }
    }
    class Program
    {
        static int MAXLEN = 100;
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                SqrtResult rlt = Sqrt(i, 99);
                if (rlt.DecimalDigits == null)
                    continue;
                sum += rlt.DecimalDigits.Sum() + rlt.IntergerValue;
            }
            Console.WriteLine("Result is {0}", sum);
        }
        static SqrtResult Sqrt(int num,int digits)
        {
            
            List<int> splite = spliteNum(num);
            int remain = 0;
            int currVal = 0;
            bool isFirst = true;
            int integerValue = 0;
            // 计算整数部分
            for (int i = splite.Count - 1; i >= 0; i--)
            {
                int currPart = 0;
                if (isFirst)
                {
                    currPart = splite[i] + remain * 100;
                    currVal = (int)Math.Sqrt(currPart);
                    remain = currPart - currVal * currVal;
                    integerValue = integerValue * 10 + currVal;
                    isFirst = false;
                    continue;
                }
                currPart = splite[i] + remain * 100;
                int p = 0;
                int sum = (integerValue * 20 + p) * p;
                while (sum <= currPart)
                {
                    p++;
                    sum = (integerValue * 20 + p) * p;
                }
                p--;
                sum = (integerValue * 20 + p) * p;
                integerValue = integerValue * 10 + p;
                remain = currPart - sum;
            }
            if (remain == 0)
            {
                return new SqrtResult() { IntergerValue = integerValue };
            }
            SqrtResult rlt = new SqrtResult() { IntergerValue = integerValue, DecimalDigits = new List<int>() };
            // 计算小数部分
            BigInteger bIntVal = integerValue;
            BigInteger bRemain = remain;
            for (int i = 0; i < digits; i++)
            {
                BigInteger currPart = bRemain * 100;
                int p = 1;
                BigInteger sum = (bIntVal * 20 + p) * p;
                while (sum <= currPart)
                {
                    p++;
                    sum = (bIntVal * 20 + p) * p;
                }
                p--;
                sum = (bIntVal * 20 + p) * p;
                bRemain = currPart - sum;
                bIntVal = bIntVal * 10 + p;
                rlt.DecimalDigits.Add(p);
            }
            return rlt;
        }
        static List<int> spliteNum(int num)
        {
            List<int> split= new List<int>();
            int temp = num;
            if (temp >= 100)
            {
                split.Add(temp % 100);
                temp = temp / 100;
            }
            split.Add(temp);
            return split;
        }
    }
}
