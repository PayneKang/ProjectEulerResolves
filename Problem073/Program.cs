using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem073
{
    class Program
    {
        const int MAXNUM = 12000;
        static int[][] FactMatrix;
        static void Main(string[] args)
        {            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            FactorsGenerator fg = new FactorsGenerator();
            float min = 1f/3;
            float max = 1f / 2;
            FactMatrix = new int[MAXNUM + 1][];
            for(int i = 0; i <= MAXNUM; i ++){
                FactMatrix[i] = fg.GeneratorDistinctFactors(i).ToArray();
            };
            sw.Stop();
            Console.WriteLine("init base data time used {0}m{1}s{2}ms", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            sw.Restart();
            int result = 0;
            for (int i = MAXNUM; i >= 2; i--)
            {
                // 计算小于此i数字所有的互质数
                for (int j = 1; j < i; j++)
                {
                    // 检查是不是互质数
                    if (!IsReltavePrime(i, j))
                    {
                        continue;
                    }
                    float val = (float)j / i;
                    if (val <= min)
                        continue;
                    if (val >= max)
                        continue;
                    result++;
                }
                // 统计在1/3 和 1/2的数字
            }
            sw.Stop();
            Console.WriteLine("result is {0}, time used {1}m{2}s{3}ms",result,sw.Elapsed.Minutes,sw.Elapsed.Seconds,sw.Elapsed.Milliseconds);
        }
        static bool IsReltavePrime(int a, int b)
        {
            int[] facta = FactMatrix[a];
            int[] factb = FactMatrix[b];
            if (facta.Length == 0 || factb.Length == 0)
            {
                return true;
            }
            foreach (int fa in facta)
            {
                if (b % fa == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
