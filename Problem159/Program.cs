using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem159
{
    class Program
    {
        private static bool[] primes = new PrimeGenerator().CheckPrimeNumber(1000000);
        private static int[] mdrsrlts = new int[1000001];
        private static int[] drsrlts = new int[1000001];
        static void Main(string[] args)
        {
            drsrlts[1] = 1;
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 999999; i >1 ; i--)
            {
                int mdrs = Program.mdrs(i);
                result += mdrs;
            }
            sw.Stop();
            Console.WriteLine("result is {0},timeused:{1}s{2}ms",result,sw.Elapsed.Seconds ,sw.Elapsed.Milliseconds);
        }

        static int drs(int num)
        {
            if (drsrlts[num] > 0)
                return drsrlts[num];
            int rlt = num%10;
            int temp = num/10;
            while (temp > 0)
            {
                rlt += temp%10;
                temp /= 10;
            }
            while (rlt >= 10)
            {
                rlt = drs(rlt);
            }
            drsrlts[num] = rlt;
            return rlt;
        }
        static int mdrs(int num)
        {
            if (mdrsrlts[num] > 0)
                return mdrsrlts[num];
            if (primes[num])
            {
                mdrsrlts[num] = drs(num);
                return mdrsrlts[num];
            }
            int currmdrs = drs(num);
            int terminal = (int) Math.Sqrt(num) + 1;
            if (terminal > num)
                terminal = num;
            for (int i = 2; i <= terminal; i++)
            {
                if (num%i != 0)
                    continue;
                int j = num/i;
                int currdrs = mdrs(i) + mdrs(j);
                if(currdrs < currmdrs)
                    continue;
                currmdrs = currdrs;
            }
            mdrsrlts[num] = currmdrs;
            return currmdrs;
        }
    }
}
