using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem074
{
    class Program
    {
        static int[] factorials = new int[10];
        static Dictionary<int,int> nextNumDic = new Dictionary<int,int>();
        const int MAXNUM = 1000000;
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            InitFactorials();
            int result = 0;
            for (int i = 1; i < MAXNUM; i++)
            {
                int length = CountUnloopLink(i);
                if(length == 60)
                    result ++;
            }
            sw.Stop();
            Console.WriteLine("result is {0}, time used {1}m{2}s{3}ms", result, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
        }
        static void InitFactorials()
        {
            factorials[0] = 1;
            for (int i = 1; i < 10; i++)
            {
                factorials[i] = factorials[i - 1] * i;
            }
        }
        static int CountUnloopLink(int num)
        {
            List<int> link = new List<int>();
            int temp = num;
            while (true)
            {
                if (link.Contains(temp))
                {
                    return link.Count;
                }
                link.Add(temp);
                if (nextNumDic.ContainsKey(temp))
                {
                    temp = nextNumDic[temp];
                    continue;
                }
                int nextNum = 0;
                int[] digits = NumberUtils.SplitNumber(temp, 1);
                foreach (int d in digits)
                {
                    nextNum += factorials[d];
                }
                nextNumDic.Add(temp, nextNum);
                temp = nextNum;
            }
        }
    }
}
