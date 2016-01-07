using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem060
{
    class Program
    {
        static PrimeGenerator pg = new PrimeGenerator();
        static void Main(string[] args)
        {
            int MAX_NUM = 50000;
            Dictionary<int, List<int>> primeMap = new Dictionary<int, List<int>>();
            Dictionary<int, object> skips = new Dictionary<int, object>();
            int MAX_LEN = 5;
            int minsum = int.MaxValue;
            for (int i = 3; i < MAX_NUM; i++)
            {

                if(skips.ContainsKey(i))
                    continue;

                if (!pg.CheckPrime(i))
                    continue;
                List<int> tmp = new List<int>();
                tmp.Add(i);
                int len = 1;
                for (int j = i+1; j < MAX_NUM; j++)
                {
                    if (len >= MAX_LEN)
                        break;
                    if (!pg.CheckPrime(j))
                        continue;

                    if (j == 673)
                    {
                    }
                    if (!CheckRel(j, tmp))
                        continue;
                    tmp.Add(j);
                    len++;
                }

                if (tmp.Count != MAX_LEN)
                {
                    continue;
                }
                break;
            }
        }

        static bool CheckRel(int num, List<int> listNum)
        {
            if (listNum.Count == 0)
                return true;

            foreach (int ln in listNum)
            {
                int numA = int.Parse(string.Format("{0}{1}", num, ln));
                if (!pg.CheckPrime(numA))
                    return false;

                int numB = int.Parse(string.Format("{0}{1}", ln,num));
                if (!pg.CheckPrime(numB))
                    return false;
            }
            return true;
        }
    }
}
