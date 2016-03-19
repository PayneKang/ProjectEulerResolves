using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem060
{
    class Program
    {
        const int PRIME_LIMIT = 100000;
        static PrimeGenerator pg = new PrimeGenerator();
        static bool[] primeMark;
        static void Main(string[] args)
        {
            int[] primes = pg.GetPrimesBelowOneMillion().Where(x => x < PRIME_LIMIT).ToArray();
            primeMark = pg.CheckPrimeNumber(PRIME_LIMIT);
            Dictionary<int, Dictionary<int, bool>> PrimeContat = new Dictionary<int, Dictionary<int, bool>>();
            #region 找出所有的素数对
            for (int i = 0; i < primes.Length; i++)
            {
                for (int j = i + 1; j < primes.Length; j++)
                {
                    if (PrimeContat.ContainsKey(primes[i]) && PrimeContat[primes[i]].ContainsKey(primes[j]))
                        continue;
                    bool isContat = CheckContact(primes[i], primes[j]);
                    if (!isContat)
                        continue;
                    if (PrimeContat.ContainsKey(primes[i]))
                    {
                        if (PrimeContat[primes[i]].ContainsKey(primes[j]))
                            continue;
                        PrimeContat[primes[i]].Add(primes[j], isContat);
                    }
                    else
                    {
                        Dictionary<int, bool> tmp = new Dictionary<int, bool>();
                        tmp.Add(primes[j], isContat);
                        PrimeContat.Add(primes[i], tmp);
                    }
                    if (PrimeContat.ContainsKey(primes[j]))
                    {
                        if (PrimeContat[primes[j]].ContainsKey(primes[i]))
                            continue;
                        PrimeContat[primes[j]].Add(primes[i], isContat);

                    }
                    else
                    {
                        Dictionary<int, bool> tmp = new Dictionary<int, bool>();
                        tmp.Add(primes[i], isContat);
                        PrimeContat.Add(primes[j], tmp);
                    }
                }
            }
            #endregion


        }
        static bool CheckContact(int a, int b)
        {
            int count = 0;
            int tempb = b;
            while (tempb > 0)
            {
                count++;
                tempb /= 10;
            }
            int tmpab = a * (int)Math.Pow(10, count) + b;
            if (tmpab > PRIME_LIMIT || tmpab < 0)
            {
                return false;
            }
            count = 0;
            int tempa = a;
            while (tempa > 0)
            {
                count++;
                tempa /= 10;
            }
            int tmpba = b * (int)Math.Pow(10,count) + a;
            if (tmpba > PRIME_LIMIT || tmpba < 0)
            {
                return false;
            }
            return primeMark[tmpab] && primeMark[tmpba];
        }

    }
}
