using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem062
{
    class Program
    {
        const int COUNT = 5;
        static void Main(string[] args)
        {
            int i = 1;
            Dictionary<string, List<LargeNumberModel>> nums = new Dictionary<string, List<LargeNumberModel>>();
            while (true)
            {
                LargeNumberModel num = Cube(i);
                string sign = SignNum(num);
                if (!nums.ContainsKey(sign))
                {
                    List<LargeNumberModel> numItem = new List<LargeNumberModel>();
                    nums.Add(sign, numItem);
                }
                nums[sign].Add(num);
                i++;
                if (nums[sign].Count == COUNT)
                {
                    Console.WriteLine(string.Format("result is {0}", nums[sign].First().ToString()));
                    return;
                }
            }
        }
        static LargeNumberModel Cube(int num)
        {
            LargeNumberModel result = new LargeNumberModel(num.ToString());
            result = result * num;
            result = result * num;
            return result;
        }
        static string SignNum(LargeNumberModel num)
        {
            string numStr = num.ToString();
            return new string(numStr.OrderBy(x => x).ToArray());
        }
    }
}
