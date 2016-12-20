using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.PrimeChecker;
using Kang.Algorithm.BaseLib;

namespace Problem501
{
    class Program
    {
        private const double oneOfThree = 1d/3d;
        private const long Terminal = 1000;
        private static List<long> primes = new List<long>();
        private static List<long> result = new List<long>(); 

        private static void Main(string[] args)
        {

            long tst = MeisselLehmerPrimeCounter.PrimeCount(125000);
            for (long i = 2; i <= 125000; i++)
            {
                if (!MillerRabinCheck.isPseudoPrime(i))
                    continue;
                primes.Add(i);
            }
            long count2 = 0;
            long count = 0;
            // 计算一个质因数的值
            for (int i = 0; i < primes.Count; i++)
            {
                long prime = primes[i];
                long num = (long) Math.Pow(prime, 7);
                if (num > Terminal)
                    break;
                count++;
                count2++;
            }

            // 计算两个质因数的值
            for (int i = 0; i < primes.Count; i++)
            {
                long num1 = primes[i];
                long tmp = num1 * num1 * num1;
                if (tmp > Terminal)
                    break;
                long maxThird = Terminal / tmp;
                int diff = maxThird >= num1 ? 1 : 0;
                if (MillerRabinCheck.isPseudoPrime(maxThird))
                    maxThird++;
                long primeCount = MeisselLehmerPrimeCounter.PrimeCount(maxThird);
                long tmp2 = getPrimeCount(maxThird);
                count += primeCount - diff;
                for (int j = 0; j < primes.Count; j++)
                {
                    if (i == j)
                        continue;
                    long num2 = primes[j];
                    long sum = tmp * num2;
                    if (sum > Terminal)
                        break;
                    result.Add(sum);
                    count2++;
                }
            }


            // 计算三个质因数的值
            for (int i = 0; i < primes.Count; i++)
            {
                long num1 = primes[i];
                long tmp = num1*num1*num1;
                if (tmp > Terminal)
                    break;
                for (int j = i + 1; j < primes.Count; j++)
                {
                    long num2 = primes[j];
                    tmp = num1*num1*num2;
                    if (tmp > Terminal)
                        break;
                    for (int k = j + 1; k < primes.Count; k++)
                    {
                        long num3 = primes[k];
                        long sum = num1*num2*num3;
                        if (sum > Terminal)
                            break;
                        count++;
                        count2++;
                    }
                }


            }
            result = result.OrderBy(x => x).ToList();

        }


        static long FindMaxDivisorNumber(long num)
        {
            double result = Math.Pow(num, oneOfThree);
            return (long)result;
        }
        static long getPrimeCount(long num)
        {
            int[] pgs = new PrimeGenerator().GetPrimesBelowOneMillion();
            long count = 0;
            foreach (int i in pgs)
            {
                if (i >= num)
                    break;
                count++;
            }
            return count;
        }
    }
}
