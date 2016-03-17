using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.Models
{
    public class RomaNumber
    {
        static char[] ROMACHARACTORS = new char[] { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
        static Dictionary<string, int> romaVals = new Dictionary<string, int>();
        static Dictionary<int, string> valRomaStr = new Dictionary<int, string>();
        private RomaNumber() { }
        public RomaNumber(int val)
        {
            this.Val = val;
        }
        public RomaNumber(string strVal)
        {
            this.StrVal = strVal;
        }
        private string strVal;
        public string StrVal
        {
            get { return this.strVal; }
            private set
            {
                this.strVal = value;
                SetVal();
                SetShortestVal();
            }
        }
        private int val;
        public int Val
        {
            get
            {
                return this.val;
            }
            private set
            {
                this.val = value;
                SetShortestVal();
            }
        }
        public string ShortestVal { get; private set; }
        private void SetShortestVal()
        {
            int[] keys = valRomaStr.Keys.ToArray();
            StringBuilder sb = new StringBuilder();
            int temp = this.Val;
            foreach (int key in keys)
            {
                while (temp >= key)
                {
                    sb.Append(valRomaStr[key]);
                    temp -= key;
                }
            }
            this.ShortestVal = sb.ToString();
        }
        private void SetVal()
        {
            List<string> items = ParseRoman(this.StrVal);
            int sum = 0;
            foreach (string item in items)
            {
                sum += romaVals[item];
            }
            this.Val = sum;
        }

        static RomaNumber()
        {
            InitRomaVals();
        }
        private List<string> ParseRoman(string item)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < item.Length; index++)
            {
                char chr = item[index];
                sb.Append(chr);
                if (index == item.Length - 1)
                {
                    string str = sb.ToString();
                    foreach (char tmpchr in str)
                    {
                        result.Add(new string(tmpchr, 1));
                    }
                    return result;
                }
                char nextChr = item[index + 1];
                if (Compare(nextChr, chr) == 1)
                {
                    sb.Append(nextChr);
                    index++;
                    result.Add(sb.ToString());
                    sb.Clear();
                    continue;
                }
                if (Compare(nextChr, chr) == -1)
                {
                    string str = sb.ToString();
                    foreach (char tmpchr in str)
                    {
                        result.Add(new string(tmpchr, 1));
                    }
                    sb.Clear();
                    continue;
                }
            }
            return result;
        }
        private int Compare(char left, char right)
        {
            if (left == right)
                return 0;
            int iLeft = -1;
            int iRight = -1;
            for (int i = 0; i < ROMACHARACTORS.Length; i++)
            {
                if (left.Equals(ROMACHARACTORS[i]))
                {
                    iLeft = i;
                    break;
                }
            }
            for (int i = 0; i < ROMACHARACTORS.Length; i++)
            {
                if (right.Equals(ROMACHARACTORS[i]))
                {
                    iRight = i;
                    break;
                }
            }
            if (iLeft < iRight)
                return 1;
            return -1;
        }
        static void InitRomaVals()
        {
            romaVals.Add("M", 1000);
            romaVals.Add("CM", 900);
            romaVals.Add("D", 500);
            romaVals.Add("CD", 400);
            romaVals.Add("C", 100);
            romaVals.Add("XC", 90);
            romaVals.Add("L", 50);
            romaVals.Add("XL", 40);
            romaVals.Add("X", 10);
            romaVals.Add("IX", 9);
            romaVals.Add("V", 5);
            romaVals.Add("IV", 4);
            romaVals.Add("I", 1);

            valRomaStr.Add(1000, "M");
            valRomaStr.Add(900, "CM");
            valRomaStr.Add(500, "D");
            valRomaStr.Add(400, "CD");
            valRomaStr.Add(100, "C");
            valRomaStr.Add(90, "XC");
            valRomaStr.Add(50, "L");
            valRomaStr.Add(40, "XL");
            valRomaStr.Add(10, "X");
            valRomaStr.Add(9, "IX");
            valRomaStr.Add(5, "V");
            valRomaStr.Add(4, "IV");
            valRomaStr.Add(1, "I");
        }
    }
}
