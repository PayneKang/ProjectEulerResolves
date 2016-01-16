using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem060
{
    class Program
    {
        const int MAX_LEN = 4;
        static PrimeGenerator pg = new PrimeGenerator();
        static void Main(string[] args)
        {
            int[] primes = pg.GetPrimesBelowOneMillion();
            Dictionary<int, List<int>> group = new Dictionary<int, List<int>>();
            foreach (int i in primes)
            {
                group.Add(i, new List<int>() { i }); 
            }
        }

        static bool CheckRel(int num, List<int> listNum)
        {
            return false;
        }
    }
}
