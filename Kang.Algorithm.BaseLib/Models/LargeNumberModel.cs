using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.Models
{
    public class LargeNumberModel
    {
        public LargeNumberModel() { }
        public int[] Digits { get; set; }
        public int NumberLength { get {
            if (Digits == null)
                return 0;
            return Digits.Length;
        } 
        }
        public LargeNumberModel(string numStr)
        {
            Digits = new int[numStr.Length];
            for (int i = 0; i < numStr.Length; i++)
            {
                Digits[i] = int.Parse(new string(numStr[i],1));
            }
        }
        public override bool Equals(object obj)
        {
            LargeNumberModel item = (LargeNumberModel)obj;
            if (this.NumberLength != item.NumberLength)
                return false;
            for (int i = 0; i < this.NumberLength; i++)
            {
                if (this.Digits[i] != item.Digits[i])
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Digits.Length ; i++)
            {
                sb.Append(Digits[i]);
            }
            return sb.ToString();
        }
        public static LargeNumberModel operator *(LargeNumberModel left, LargeNumberModel right)
        {
            LargeNumberModel result = new LargeNumberModel("0");
            for (int i = 0; i < right.NumberLength; i++)
            {
                result = result + left * (right.Digits[i] * (int)Math.Pow(10, right.NumberLength - i - 1));
            }
            return result;
        }
        public static LargeNumberModel operator *(LargeNumberModel left, int right)
        {
            List<int> result = new List<int>();
            int highdigit = 0;
            for (int i = left.NumberLength - 1 ; i >= 0; i--)
            {
                int digit = left.Digits[i] * right + highdigit;
                result.Add(digit % 10);
                highdigit = digit / 10;
            }
            while (highdigit > 10)
            {
                result.Add(highdigit % 10);
                highdigit = (highdigit / 10);
            }
            if (highdigit > 0)
            {
                result.Add(highdigit);
            }
            LargeNumberModel resultNum = new LargeNumberModel();
            result.Reverse();
            resultNum.Digits = result.ToArray();
            return resultNum;
        }
        public static LargeNumberModel operator +(LargeNumberModel left, LargeNumberModel right)
        {
            LargeNumberModel bigger = left.NumberLength >= right.NumberLength ? left : right;
            LargeNumberModel smaller = left.NumberLength < right.NumberLength ? left : right;
            List<int> result = new List<int>();
            int highdigit = 0;
            for (int i = bigger.NumberLength - 1, m = smaller.NumberLength - 1; i >= 0; i--, m--)
            {
                if (m >= 0)
                {
                    int digit = smaller.Digits[m] + bigger.Digits[i] + highdigit;
                    result.Add(digit % 10);
                    highdigit = digit / 10;
                    continue;
                }
                int digitb = bigger.Digits[i] + highdigit;
                result.Add(digitb % 10);
                highdigit = digitb / 10;
            }
            if (highdigit > 0)
                result.Add(highdigit);
            LargeNumberModel resultNum = new LargeNumberModel();
            result.Reverse();
            resultNum.Digits = result.ToArray();
            return resultNum;
        }
        public static LargeNumberModel operator +(LargeNumberModel left, int right)
        {
            return left + new LargeNumberModel(right.ToString());
        }
        public static LargeNumberModel operator ++(LargeNumberModel left)
        {
            List<int> result = new List<int>();
            int highdigit = 1;
            for (int i = left.NumberLength - 1; i >= 0; i--)
            {
                int digitb = left.Digits[i] + highdigit;
                result.Add(digitb % 10);
                highdigit = digitb / 10;
            }
            if (highdigit > 0)
                result.Add(highdigit);
            LargeNumberModel resultNum = new LargeNumberModel();
            result.Reverse();
            resultNum.Digits = result.ToArray();
            return resultNum;
        }
        public static bool operator >(LargeNumberModel left, LargeNumberModel right)
        {
            if (left.NumberLength > right.NumberLength)
                return true;
            if (left.NumberLength < right.NumberLength)
                return false;
            for (int i = 0; i < left.NumberLength; i++)
            {
                if (left.Digits[i] > right.Digits[i])
                    return true;
                if (left.Digits[i] < right.Digits[i])
                    return false;
            }
            return false;
        }
        public static bool operator <(LargeNumberModel left, LargeNumberModel right)
        {
            if (left.NumberLength > right.NumberLength)
                return false;
            if (left.NumberLength < right.NumberLength)
                return true;
            for (int i = 0; i < left.NumberLength; i++)
            {
                if (left.Digits[i] > right.Digits[i])
                    return false;
                if (left.Digits[i] < right.Digits[i])
                    return true;
            }
            return false;
        }
    }
}
