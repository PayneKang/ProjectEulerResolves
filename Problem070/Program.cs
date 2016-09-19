using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem070
{
    class Program
    {
        const int MAXNUM = 10000000;
        private static Number[] Phis = new Number[MAXNUM];
        static bool[] primes = new PrimeGenerator().CheckPrimeNumber(MAXNUM);
        List<int> checkedPrimes = new List<int>();
        class Number
        {
            public Number(int value)
            {
                this.Value = value;
                this.Primes = new List<int>();
                this.Phis = value - 1;
            }
            public int Phis { get; set; }
            public int Value { get; set; }
            public List<int> Primes { get; set; }
        }

        static void Main(string[] args)
        {
            Phis[0] = new Number(0);
            Phis[1] = new Number(1);
            for (int i = 2; i < MAXNUM; i++)
            {
                Phis[i] = new Number(i);
            }
            for (int i = 2; i < MAXNUM; i++)
            {
                if (!primes[i])
                    continue;
                int index = i + i;
                while (index < MAXNUM)
                {
                    Phis[index].Primes.Add(i);
                    index += i;
                }
            }
            float min = 3f;
            int minn = 0;
            for (int i = 2; i < MAXNUM; i++)
            {
                if (i == 87109) { 

                }
                if (primes[i])
                    continue;
                int totalCount = 0;
                foreach(int p in Phis[i].Primes){
                    totalCount += i / p;
                }                
                int dumplicateCount = 0;
                for (int pi = 0; pi < Phis[i].Primes.Count - 1; pi++ )
                {
                    int a = Phis[i].Primes[pi];
                    for (int ppi = pi + 1; ppi < Phis[i].Primes.Count; ppi++)
                    {
                        int b = Phis[i].Primes[ppi];
                        dumplicateCount += (i / (a * b)) - 1;
                    }
                }                
                Phis[i].Phis = (i - 1) - totalCount + Phis[i].Primes.Count + dumplicateCount;
                if (!checkPositive(i, Phis[i].Phis))
                    continue;
                float currval = (float)i / Phis[i].Phis;
                if(currval < min)
                {
                    min = currval;
                    minn = i;
                }
            }
            Console.WriteLine("Result is {0}", minn);
        }
        static bool checkPositive(int a, int b)
        {
            int[] sa = NumberUtils.SplitNumber(a, 1).OrderBy(x => x).ToArray();
            int[] sb = NumberUtils.SplitNumber(b, 1).OrderBy(x => x).ToArray();
            if (sa.Length != sb.Length)
                return false;
            for (int i = 0; i < sa.Length; i++)
            {
                if (sa[i] != sb[i])
                    return false;
            }
            return true;
        }
    }
}
