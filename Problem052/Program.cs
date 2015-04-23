using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem052
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            while (true)
            {
                int len = NumberUtils.GetNumberLength(x);
                if (x / (int)(Math.Pow(10, len - 1)) > 1)
                {
                    x = (int)Math.Pow(10, len);
                    continue;
                }
                List<int> sx = NumberUtils.SplitNumber((long)x, 1).OrderBy(i => i).ToList();
                List<int> s2x = NumberUtils.SplitNumber((long)(x * 2), 1).OrderBy(i => i).ToList();
                List<int> s3x = NumberUtils.SplitNumber((long)(x * 3), 1).OrderBy(i => i).ToList();
                List<int> s4x = NumberUtils.SplitNumber((long)(x * 4), 1).OrderBy(i => i).ToList();
                List<int> s5x = NumberUtils.SplitNumber((long)(x * 5), 1).OrderBy(i => i).ToList();
                List<int> s6x = NumberUtils.SplitNumber((long)(x * 6), 1).OrderBy(i => i).ToList();
                bool equals = true;
                for (int i = 0; i < sx.Count; i++)
                {
                    int temp = sx[i];
                    if (s2x[i] != temp)
                    {
                        equals = false;
                        break;
                    }
                    if (s3x[i] != temp)
                    {
                        equals = false;
                        break;
                    }
                    if (s4x[i] != temp)
                    {
                        equals = false;
                        break;
                    }
                    if (s5x[i] != temp)
                    {
                        equals = false;
                        break;
                    }
                    if (s6x[i] != temp)
                    {
                        equals = false;
                        break;
                    }
                }
                if (equals)
                    break;
                x++;
            }
            Console.WriteLine(string.Format("Result is {0}", x));
        }
    }
}
