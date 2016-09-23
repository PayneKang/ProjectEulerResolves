using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Kang.Algorithm.BaseLib;
using Kang.Algorithm.BaseLib.Models;

namespace Problem099
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("p099_base_exp.txt");
            int maxline = 0;
            int lineindex = 0;
            double max = 0f;
            foreach (string line in lines)
            {
                lineindex++;
                string[] nums = line.Split(',');
                double basenum = Math.Log10(double.Parse(nums[0]));
                double lnum = basenum*double.Parse(nums[1]);
                if (lnum > max)
                {
                    maxline = lineindex;
                    max = lnum;
                }

            }
            Console.WriteLine("Result is {0}", maxline);
        }
    }
}
