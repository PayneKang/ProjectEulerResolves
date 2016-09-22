using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem098
{
    class Program
    {
        static Dictionary<string, List<string>> SignedWords = new Dictionary<string, List<string>>();
        static Dictionary<char, int> BuildCharactorMapping(string word, long number)
        {
            int[] digits = NumberUtils.SplitNumber(number, 1);
            Dictionary<char, int> rlt = new Dictionary<char,int>();
            for (int i = 0; i < word.Length ; i++)
            {
                char c = word[i];
                if (!rlt.ContainsKey(c))
                {
                    rlt.Add(c, digits[word.Length - i - 1]);
                    continue;
                }
                if (rlt[c] != digits[i])
                    return null;
            }
            if (rlt.Values.Distinct().Count() != word.ToCharArray().Distinct().Count())
                return null;
            return rlt;
        }
        static void Main(string[] args)
        {
            int longest = 0;
            // 为所有单词制作签名并加入到签名相同的对应签名组
            string files = FileReader.ReadFile("p098_words.txt");
            string[] words = files.Replace("\"", "").Split(',');
            foreach (string word in words)
            {
                string sign = string.Join("", word.OrderBy(x => x));
                if (!SignedWords.ContainsKey(sign))
                    SignedWords.Add(sign, new List<string>());
                SignedWords[sign].Add(word);
                int length = word.Length;
                if (length > longest)
                    longest = length;
            }
            List<string[]> pairWords = new List<string[]>();

            // 将同一签名组的单词两两分组，创建对应的组合
            foreach (string key in SignedWords.Keys)
            {
                if (SignedWords[key].Count < 2)
                    continue;
                List<string[]> pairs = CombinationProvider.BuildDistinctCombination<string>(SignedWords[key].ToArray(), 2);
                pairWords.AddRange(pairs);
            }
            Dictionary<long, List<long>> pows = new Dictionary<long, List<long>>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long m = 10;
            pows.Add(m, new List<long>());
            for (long i = 1; ; i++)
            {
                long pow = i * i;
                if (pow >= (long)100000000000000)
                {
                    break;
                }
                if (pow < m)
                {
                    pows[m].Add(pow);
                }
                else
                {
                    m *= 10;
                    pows.Add(m, new List<long>() { pow });
                }
            }
            sw.Stop();
            Debug.WriteLine("time used {0}s{1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            // 计算这一组合是不是重排平方单词对
            long maxnum = 0;
            foreach (string[] pair in pairWords)
            {
                int len = pair[0].Length;
                long key = 1;
                for (int i = 0; i < len; i++)
                {
                    key *= 10;
                }
                long[] nums = pows[key].OrderByDescending(x => x).ToArray();
                foreach (long num in nums)
                {
                    Dictionary<char, int> mapping = BuildCharactorMapping(pair[0], num);
                    if (mapping == null)
                    {
                        continue;
                    }
                    if (mapping[pair[1][0]] == 0)
                        continue;
                    long num2 = BuildNumber(pair[1], mapping);
                    if (!nums.Contains(num2))
                        continue;
                    if (maxnum < num)
                        maxnum = num;
                }
                foreach (long num in nums)
                {
                    Dictionary<char, int> mapping = BuildCharactorMapping(pair[1], num);
                    if (mapping == null)
                    {
                        continue;
                    }
                    if (mapping[pair[0][0]] == 0)
                        continue;
                    long num2 = BuildNumber(pair[0], mapping);
                    if (!nums.Contains(num2))
                        continue;
                    if (maxnum < num)
                        maxnum = num;
                }
            }
        }

        static char[] chrs = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static long BuildNumber(string word, Dictionary<char, int> mapping)
        {
            string tmp = word;
            foreach (char key in mapping.Keys)
            {
                tmp = tmp.Replace(key, chrs[mapping[key]]);
            }
            return long.Parse(tmp);
        }
    }
}
