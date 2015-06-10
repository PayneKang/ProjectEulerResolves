using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem059
{
    class Program
    {
        static string[] normalWords = new string[] { "here", "there", "same", "value" };
        static void Main(string[] args)
        {
            // 创建密文的char列表
            string str = FileReader.ReadFile(@"p059_cipher.txt").Replace("\n","");
            string[] chrAsciiStr = str.Split(',');
            char[] chrArray = new char[chrAsciiStr.Length];
            for (int i = chrAsciiStr.Length - 1; i >= 0; i--)
            {
                chrArray[i] = (char)int.Parse(chrAsciiStr[i]);
            }
            string source = new string(chrArray);
            // 创建可能的Key列表
            char[] seeds = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            List<char[]> keys = CombinationProvider.BuildCombination<char>(seeds, 3);
            string decriptStr = "";
            foreach (char[] key in keys)
            {
                bool found = false;
                decriptStr = decript(chrArray, key);
                foreach (string word in normalWords)
                {
                    if (decriptStr.Contains(word))
                    {
                        found = true;
                        break;
                    }
                    if (found)
                        break;
                }
                if (found)
                    break;
            }
            long sum = 0;
            foreach(char chr in decriptStr){
                sum += chr;
            }
            Console.WriteLine("Result is {0}", sum);
        }
        static string decript(char[] source, char[] key)
        {
            char[] result = new char[source.Length];
            for (int i = 0, j = 0; i<source.Length ; i++,j++)
            {
                if (j == 3)
                    j = 0;
                result[i] = (char)(source[i] ^ key[j]);
            }
            return new string(result);
        }
    }
}
