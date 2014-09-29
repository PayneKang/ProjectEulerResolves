using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem012
{
    class Program
    {
        static void Main(string[] args)
        {
            string matrixNumbers = FileReader.ReadFile("Nums.txt", System.Text.Encoding.UTF8);
            string[] nums = matrixNumbers.Replace("\r\n", "|").Split('|');
            LargeNumberModel result = new LargeNumberModel("0");
            foreach (string num in nums)
            {
                LargeNumberModel ln = new LargeNumberModel(num);
                result = result + ln;
            }
            Console.WriteLine(result.ToString().Substring(0,10));
            Debug.WriteLine(result.ToString().Substring(0, 10));
            Console.Read();
        }
    }
}
