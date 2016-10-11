using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem193
{
    public class Class1
    {
        static bool[] primes;
        public static void Main(string[] args)
        {
            InitPrimes();
            Test();
            Do();
        }
        static void Test()
        {
            int max = 200;
            bool[][] mark = new bool[max + 1][];
            int terminal = (int)Math.Sqrt(max);
            for (int i = 2; i <= terminal; i++)
            {
                if (!primes[i])
                    continue;
                int step = i * i;
                for (int j = step; j <= max;)
                {
                    if(mark[j] == null)
                        mark[j] = new bool[2];
                    if (mark[j][0])
                        mark[j][1] = true;
                    mark[j][0] = true;
                    j += step;
                }
            }
            int count = mark.Count(x => x == null || x[0] == false) - 1;
        }
        static void InitPrimes()
        {
            string str = FileReader.ReadFile("primes_100000000.txt");
            string[] p = str.Split(',');
            primes = new bool[100000000 + 1];
            for (int i = 0; i < p.Length; i++)
            {
                primes[long.Parse(p[i])] = true;
            }
        }
        static void Do()
        {

            long max = 200;
            long terminal = (long)Math.Sqrt(max);
            long result = max;
            for (int i = 2; i <= terminal; i++)
            {
                if (!primes[i])
                    continue;
                result -= max / (i * i);
            }
            // 找出所有小于 max 的素数平方
            List<long> ps = new List<long>();
            for (long i = 2; i <= terminal; i++)
            {
                if (!primes[i])
                    continue;
                ps.Add(i * i);
            }
            // 找出所有乘积小于 max 的组合数
        }
    }
}
