using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem427
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrs = new int[]{
                111,112,113,121,122,123,131,132,133,
                211,212,213,221,222,223,231,232,233,
                311,312,313,321,322,323,331,332,333
            };
            int result = 0;
            int[] cs = new int[4];
            foreach (int n in arrs)
            {
                int[] ds = NumberUtils.SplitNumber(n, 1);
                int maxCount = 0;
                int continueCount = 0;
                foreach()
                cs[ds] ++;
                result += ds;
            }
        }
    }
}
