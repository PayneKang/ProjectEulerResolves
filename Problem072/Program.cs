using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem072
{
    class Program
    {
        static int MAXINT = 1000000;
        static int[] phiResult;
        static bool[] primes;
        static void Main(string[] args)
        {
            long result = 0;
            primes = new PrimeGenerator().CheckPrimeNumber(MAXINT);
            phiResult = new int[MAXINT + 1];
            CalculatePrimePhi();
            for (int i = MAXINT; i >= 2; i--)
            {
                int count = Phi(i);
                result += count;
                if(i % 1000 == 0)
                    Console.WriteLine("Phi count of {0} is {1}", i, count);
            }
            Console.WriteLine("Result is {0}", result);
        }
        static FactorsGenerator fg = new FactorsGenerator();
        static void CalculatePrimePhi()
        {
            for (int i = 2; i <= MAXINT; i++)
            {
                if (primes[i])
                {
                    phiResult[i] = i - 1;
                    continue;
                }
                List<int> frac = fg.GeneratorFactorsBelowOneMillion(i);
                var fracGroup = frac.GroupBy(x => x);
                int count = fracGroup.Count();
                if (count == 1)
                {
                    phiResult[i] = EulerTotientFunction.Calculate(i);
                    continue;
                }
                phiResult[i] = 1;
                foreach(var item in fracGroup){
                    int num = item.First();
                    int itemcount = item.Count();
                    int sumNum = (int)Math.Pow(num, itemcount);
                    phiResult[i] *= phiResult[sumNum];
                }
            }
        }
        static int Phi(int num)
        {
            if (phiResult[num] != 0)
                return phiResult[num];
            return EulerTotientFunction.Calculate(num);
        }
    }
}
