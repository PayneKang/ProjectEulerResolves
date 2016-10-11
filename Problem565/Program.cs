using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem565
{
    class Program
    {
        class PhiModel
        {
            public int Value { get; set; }
            public List<long> Divisors { get; set; }
            public long DivisorSum { get; set; }
            public bool DivisorSumCanBeDivided(int num)
            {
                throw new NotImplementedException();
            }
        }
        const long Max = 100000000000;
        const int Divisor = 2017;
        static List<int> phiObjs;
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (long i = Max - 10000; i <= Max ; i++)
            {
                long phi = Phi(i);
            }
            sw.Stop();
            double totalSeconds = sw.Elapsed.TotalMinutes * (Max / 10000);
            /*
            phiObjs = new List<int>() { 0 };
            for (int i = 1; i <= Max; i++)
            {
                phiObjs.Add(0);
            }
            for (int i = 1; i <= Max / 2; i++)
            {
                int temp = i;
                while (temp <= Max)
                {
                    phiObjs[temp] += i;
                    temp = temp + i;
                }
            }
            for (int i = Max / 2 + 1; i <= Max; i++)
            {
                phiObjs[i] += i;
            }
            long result = S();
            */
        }
        static long S()
        {
            long result = 0;
            for (int i = 1; i <= Max; i++)
            {
                if (phiObjs[i] % Divisor == 0)
                    result += i;
            }
            return result;
        }
        static long Phi(long n)
        {
            long result = 0;
            long temp = n;
            List<int[]> divisors = new List<int[]>();
            while (temp > 0)
            {

            }
            return result;
        }
    }
}
