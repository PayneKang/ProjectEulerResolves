using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using Kang.Algorithm.BaseLib.Models;

namespace Problem089
{
    class Program
    {

        static void Main(string[] args)
        {
            string str = FileReader.ReadFile("p089_roman.txt");
            string[] strArray = str.Split('\n');
            Dictionary<string, object> unknownval = new Dictionary<string, object>();
            int count = 0;
            foreach (string item in strArray)
            {
                RomaNumber rn = new RomaNumber(item);
                if(!rn.ShortestVal.Equals(rn.StrVal)){
                    count += (rn.StrVal.Length - rn.ShortestVal.Length);
                }
            }
            Console.WriteLine("Result is {0}", count);
        }
    }
}
