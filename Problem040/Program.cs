using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using Kang.Algorithm.BaseLib;

namespace Problem040
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; ; i++)
            {
                if (sb.Length > 1000000)
                    break;
                sb.Append(i.ToString());
            }
            string str = sb.ToString();
            int test = int.Parse(str.Substring(11, 1));
            int a = int.Parse(str.Substring(0, 1));
            int b = int.Parse(str.Substring(9, 1));
            int c = int.Parse(str.Substring(99, 1));
            int d = int.Parse(str.Substring(999, 1));
            int e = int.Parse(str.Substring(9999, 1));
            int f = int.Parse(str.Substring(99999, 1));
            int g = int.Parse(str.Substring(999999, 1));
            int result = a * b*c*d*e*f*g;
            Console.WriteLine(string.Format("Result is {0}",result));
        }
    }
}
