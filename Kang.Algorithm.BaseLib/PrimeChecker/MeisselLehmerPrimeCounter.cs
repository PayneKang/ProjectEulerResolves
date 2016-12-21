using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.PrimeChecker
{
    /// <summary>
    /// 使用Meissel-Lehmer算法来构建的计算某一个数以内的素数个数的算法
    /// </summary>
    public class MeisselLehmerPrimeCounter
    {
        private const long MAX = 400010;
        private const long MAXN = 100;
        private const long MAXM = 10010;
        private const long MAXP = 40000;
        private int[] counter;
        private long[][] dp;
        private int len = 0;
        private int[] primes;
        private double oneOfThree = 1.0/3;
        public MeisselLehmerPrimeCounter()
        {
            Init();
        }

        private void InitPrimes()
        {
            bool[] marks = new PrimeGenerator().CheckPrimeNumber(10000000);
            counter = new int[marks.Length];
            List<int> tmpPrimes = new List<int>();
            for (int i = 1; i < marks.Length; i++)
            {
                counter[i] = counter[i - 1];
                if (marks[i])
                {
                    tmpPrimes.Add(i);
                    counter[i] ++;
                }
            }
            primes = tmpPrimes.ToArray();
        }
        private void InitDP()
        {
            dp = new long[MAXN][];
            for (int n = 0; n < MAXN; n++)
            {
                dp[n] = new long[MAXM];
                for (int m = 0; m < MAXM; m++)
                {
                    if (n == 0)
                    {
                        dp[n][m] = m;
                        continue;
                    }
                    dp[n][m] = dp[n - 1][m] - dp[n - 1][m / primes[n - 1]];
                }
            }
        }
        private void Init()
        {
            InitPrimes();
            InitDP();
        }

        private long Phi(long num, int n)
        {
            if (n == 0)
                return num;
            if (primes[n - 1] >= num)
                return 1;
            if (num < MAXM && n < MAXN)
                return dp[n][num];
            return Phi(num, n - 1) - Phi(num/primes[n - 1], n - 1);
        }

        public long Lehmer(long num)
        {
            if (num < MAX) return counter[num];

            long w, res = 0;
            int i, a, s, c, x, y;
            s = (int)Math.Sqrt(0.9 + num);
            y = c = (int)Math.Pow(0.9 + num, oneOfThree);
            a = counter[y];
            res = Phi(num, a) + a - 1;
            for (i = a; primes[i] <= s; i++)
            {
                res = res - Lehmer(num/primes[i]) + Lehmer(primes[i]) - 1;
            }
            return res;
        }
    }
}
