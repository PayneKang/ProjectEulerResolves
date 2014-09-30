using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;

namespace Problem014
{
    class Program
    {
        static void Main(string[] args)
        {
            CollatzSequenceProvider csp = new CollatzSequenceProvider();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int max = 0;
            long startNum = 0;
            for (long i = 1000000; i > 1; i--)
            {
                csp.setStartNum(i);
                int rlt = csp.DoCalculateSequenceLength();
                if (rlt > max)
                {
                    max = rlt;
                    startNum = i;
                }
            }
            sw.Stop();
            Console.Out.WriteLine(sw.ElapsedTicks + " len : " + max + " start number : " + startNum);
            Console.Read();
        }
    }
}
