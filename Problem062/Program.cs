using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem062
{
    class Program
    {
        const int COUNT = 5;
        static void Main(string[] args)
        {
            int i = 1;
            Dictionary<string, List<BigInteger>> nums = new Dictionary<string, List<BigInteger>>();
            while (true)
            {
                BigInteger num = Cube(i);
                string sign = SignNum(num);
                if (!nums.ContainsKey(sign))
                {
                    List<BigInteger> numItem = new List<BigInteger>();
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
        static BigInteger Cube(int num)
        {
            return (BigInteger)num * num * num;
        }
        static string SignNum(BigInteger num)
        {
            string numStr = num.ToString();
            return new string(numStr.OrderBy(x => x).ToArray());
        }
    }
}
