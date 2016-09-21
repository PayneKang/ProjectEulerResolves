using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem088
{
    class Program
    {
        static int maxk = 12001;
        static int[] n = new int[maxk];
        static void getPsn(int num, int sump, int product, int start)
        {
            int k = num - sump + product;
            if (k >= maxk)
                return;
            if (num < n[k])
                n[k] = num;
            for (int i = start; i <= (maxk / num) * 2; i++)
            {
                getPsn(num * i, sump + i, product + 1, i);
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < maxk; i++)
            {
                n[i] = int.MaxValue;
            }
            getPsn(1, 1, 1, 2);
            int sum = n.Distinct().Where(x => x != int.MaxValue&& x != 1).Sum();
            int sum2 = Method2();
            Console.WriteLine("Result is {0}", sum);
        }
        static int Method2()
        {
            int maxK = 12000;
            int maxNumber = 2 * maxK;

            int numFactors = (int)(Math.Log10(maxNumber) / Math.Log10(2));
            int[] factors = new int[numFactors];

            int[] k = Enumerable.Range(0, maxK + 1).Select(x => x * 2).ToArray();
            k[1] = 0;

            factors[0] = 1;
            int curMaxFactor = 1;
            int j = 0;

            while (true)
            {
                if (j == 0)
                {
                    //at first factor
                    if (curMaxFactor == numFactors)
                        //Used all the factos we can
                        break;

                    if (factors[0] < factors[1])
                    {
                        //can increment
                        factors[0]++;
                    }
                    else
                    {
                        //add another factor
                        curMaxFactor++;
                        factors[curMaxFactor - 1] = int.MaxValue;
                        factors[0] = 2;
                    }

                    j++;
                    factors[1] = factors[0] - 1;
                }
                else if (j == curMaxFactor - 1)
                {
                    //At the max factor
                    factors[j]++;
                    int sum = 0;
                    int prod = 1;
                    for (int i = 0; i < curMaxFactor; i++)
                    {
                        prod *= factors[i];
                        sum += factors[i];
                    }

                    if (prod > maxNumber)
                    {
                        //Exceed the limit so go back
                        j--;
                    }
                    else
                    {
                        //Check the result
                        int pk = prod - sum + curMaxFactor;
                        if (pk <= maxK && prod < k[pk])
                        {
                            k[pk] = prod;
                        }
                    }
                }
                else if (factors[j] < factors[j + 1])
                {
                    //increment the reset the next factor
                    //and go up
                    factors[j]++;
                    factors[j + 1] = factors[j] - 1;
                    j++;
                }
                else if (factors[j] >= factors[j + 1])
                {
                    //Need to go further back
                    j--;
                }
            }
            return k.Distinct().Sum();
        }
    }
}
