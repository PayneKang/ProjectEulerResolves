using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem017
{
    class Program
    {
        static string[] numbers = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nighteen" };
        static string[] tennumbers = new string[] {"","", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "nighty" };
        static int[] numbersLength = new int[numbers.Length];
        static string hundred = "hundred";
        static string thousand = "thousand";
        static void Main(string[] args)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersLength[i] = numbers[i].Length;
            }
            int[] tennumbersLength = new int[tennumbers.Length];
            for (int i = 0; i < tennumbers.Length; i++)
            {
                tennumbersLength[i] = tennumbers[i].Length;
            }
            int totalCount = 0;
            for (int i = 1; i <= 1000; i++)
            {
                String num = BuildNumberWords(i);
                Debug.WriteLine(string.Format("{0}:{1}:{2}", i, num,num.Length));
                totalCount += BuildNumberWords(i).Length;
            }
            Console.WriteLine("totalLength:" + totalCount);
            Console.Read();
        }
        static string BuildNumberWords(int i)
        {
            StringBuilder sb = new StringBuilder();
            if (i == 1000)
            {
                sb.Append("OneThousand");
                return sb.ToString();
            }
            if (i / 100 > 0)
            {
                sb.Append(string.Format("{0}Hundred", numbers[i/100]));
                if (i % 100 > 0)
                    sb.Append("And");
            }
            if (i % 100 == 0)
            {
                return sb.ToString();
            }
            if (i%100 < 20)
            {
                sb.Append(numbers[i%100]);
                return sb.ToString();
            }
            sb.Append(tennumbers[(i%100) / 10]);
            if (i % 10 == 0)
                return sb.ToString();
            sb.Append(numbers[i % 10]);
            return sb.ToString();
        }
    }
}
