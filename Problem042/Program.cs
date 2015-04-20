using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem042
{
    class Program
    {
        static bool[] nums;
        static Dictionary<char,CharactorValue> charactors;
        const int MAXVAL = 1000000;
        class CharactorValue
        {
            public int SEQ { get; set; }
            public int VAL { get; set; }
        }
        static void Main(string[] args)
        {
            nums = new bool[MAXVAL + 1];
            for (int i = 1; ; i++)
            {
                int temp = ( i * (i + 1) ) / 2;
                if (temp <= 0)
                    break;
                if (temp >= MAXVAL)
                    break;
                nums[temp] = true;
            }
            char[] characs = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            charactors = new Dictionary<char, CharactorValue>();
            for (int i = 0; i < characs.Length; i++)
            {
                int temp = ( i * (i + 1) ) / 2;
                charactors.Add(characs[i], new CharactorValue() { SEQ = i + 1, VAL = temp });
            }
            string names = FileReader.ReadFile("words.txt");
            names = names.Replace("\"","").ToUpper();
            string[] nameList = names.Split(',');
            int totalcount = 0;
            foreach (string name in nameList)
            {
                int numberSum = 0;
                foreach (char chr in name)
                {
                    if (!charactors.ContainsKey(chr))
                        continue;
                    numberSum += charactors[chr].SEQ;
                }
                if (!nums[numberSum])
                    continue;
                totalcount++;
            }
            Console.WriteLine(string.Format("Result is {0}",totalcount));
        }
    }
}
