using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using Kang.Algorithm.BaseLib;
using System.Diagnostics;
using System.Threading;

namespace Problem015
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int width = 10;
            MatrixPathBuilder mpb = new MatrixPathBuilder();
            mpb.BuildNodeMartix(width, width);
                sw.Start();
                mpb.CountPath(0,0);
                sw.Stop();
                sw.Reset();
                Debug.WriteLine(string.Format("width:{0}, pathCount:{1} ; timeused:{2}", width, mpb.TotalCount, sw.ElapsedMilliseconds));
        
        }
    }
}
