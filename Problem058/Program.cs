using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem058
{
    class Program
    {
        static PrimeGenerator pg = new PrimeGenerator();
        static void Main(string[] args)
        {
            int num = 1;
            int len = 1;
            int primecount = 0;
            float ratio = 0f;
            int step = 0;
            while (true){
                len+=2;
                step = len - 1;
                num = num + step;
                primecount += pg.CheckPrime(num)?1:0;
                num = num + step;
                primecount += pg.CheckPrime(num) ? 1 : 0;
                num = num + step;
                primecount += pg.CheckPrime(num) ? 1 : 0;
                num = num + step;
                primecount += pg.CheckPrime(num) ? 1 : 0;
                ratio = (float)primecount / (float)(len * 2 - 1);
                Console.WriteLine("len:\t{0},primecount:\t{1},totalcount\t{2},ratio:\t{3}",len,primecount,len * 2 - 1,ratio);
                if (primecount * 10 < len * 2 - 1)
                {
                    Console.Out.WriteLine(string.Format("result is {0}", len));
                    break;
                }
            }
        }
    }
}
