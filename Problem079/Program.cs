using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem079
{
    class Program
    {
        class NumberDigit
        {
            public char Val { get; set; }
            public List<char> Left { get; set; }
            public List<char> Right { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<char, NumberDigit> nums = new Dictionary<char, NumberDigit>();
            string str = FileReader.ReadFile("pwd.txt").Replace("\r\n","|").Substring(1);
            string[] strArray = str.Split('|').Distinct().ToArray();
            foreach (string strItem in strArray)
            {
                char a = strItem[0];
                char b = strItem[1];
                char c = strItem[2];
                if(strItem.Equals("731")){
                }
                if (nums.ContainsKey(a))
                {
                    if (!nums[a].Right.Contains(b))
                        nums[a].Right.Add(b);
                    if (!nums[a].Right.Contains(c))
                        nums[a].Right.Add(c);
                }
                else
                {
                    nums.Add(a, new NumberDigit() { Val = a, Left = new List<char>() { }, Right = new List<char>() { b, c } });
                }
                if (nums.ContainsKey(b))
                {
                    if (!nums[b].Left.Contains(a))
                        nums[b].Left.Add(a);
                    if (!nums[b].Right.Contains(c))
                        nums[b].Right.Add(c);
                }
                else
                {
                    nums.Add(b, new NumberDigit() { Val = b, Left = new List<char>() { a }, Right = new List<char>() { c } });
                }
                if (nums.ContainsKey(c))
                {
                    if (!nums[c].Left.Contains(a))
                        nums[c].Left.Add(a);
                    if (!nums[c].Left.Contains(b))
                        nums[c].Left.Add(b);
                }
                else
                {
                    nums.Add(c, new NumberDigit() { Val = c, Left = new List<char>() { a ,b }, Right = new List<char>() { } });
                }
            }
            List<NumberDigit> numResult = nums.Values.OrderBy(x => x.Left.Count).ToList();
            StringBuilder sb = new StringBuilder();
            foreach(NumberDigit d in numResult){
                sb.Append(d.Val);
            }
            Console.WriteLine("Result is {0}", sb.ToString());
        }
    }
}
