using Kang.Algorithm.BaseLib.PrimeChecker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Problem216
{
    class Program
    {
        static object lockObj = new object();
        static int totalThreadCount = 0;
        static int totalFinishedCount = 0;
        static void Main(string[] args)
        {
            int i = 0;
            int step = 1000;
            int start, end;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (i < 50000000 / step)
            {
                if(i == 0){
                     start = 2;
                     end = step;
                }else{
                     start = i * step + 1;
                     end = (i + 1 ) * step;
                }
                PrimeCounter pc = new PrimeCounter(start,end,new Action<long>(SuccessCallBack));
                pc.StartCalculate();
                totalThreadCount++;
                i ++;
            }
            while (totalFinishedCount < totalThreadCount)
            {
                Console.WriteLine("线程数 {0}|{1}", totalFinishedCount, totalThreadCount);
                Thread.Sleep(1000);
            }
            sw.Stop();
            Console.WriteLine("Result is {0} timeused {1}m{2}s{3}ms", totalCount,(int)sw.Elapsed.TotalMinutes,sw.Elapsed.Seconds,sw.Elapsed.Milliseconds);
        }
        static long totalCount = 0;
        static void SuccessCallBack(long count)
        {
            lock (lockObj)
            {
                totalCount += count;
                totalFinishedCount++;
            }
        }
        class PrimeCounter
        {
            
            public PrimeCounter(long startNum,long endNum,Action<long> successHandler) {
                this.StartNumber = startNum;
                this.EndNumber = endNum;
                this.SuccessHandler = successHandler;
            }
            public long StartNumber { get; private set; }
            public long EndNumber { get; private set; }
            public Action<long> SuccessHandler { get; private set; }
            public void StartCalculate()
            {
                ThreadPool.QueueUserWorkItem(DoCalculate);
            }
            private void DoCalculate(object param)
            {
                long tn = 0;
                long count = 0;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (long n = this.EndNumber; n >= this.StartNumber; n--)
                {
                    tn = 2 * n * n - 1;
                    if (MillerRabinCheck.isPseudoPrime(tn))
                    {
                        count++;
                    }
                }
                if (this.SuccessHandler != null)
                    this.SuccessHandler(count);
            }
        }
    }
}
