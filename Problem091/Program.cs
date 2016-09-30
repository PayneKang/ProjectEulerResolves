using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem091
{
    class Program
    {
        static int side = 51;
        static void Main(string[] args)
        {
            int count = 0;
            for (int pi = 0; pi < side; pi++)
            {
                for (int pj = 0; pj < side; pj++)
                {
                    int[] p = new int[] {pi, pj};
                    if (pi == 0 && pj == 0)
                        continue;
                    count += Count(p);
                }
            }
            int result = count/2;
            Console.WriteLine("Result is {0}", result);
        }

        static int Count(int[] p)
        {
            int count = 0;
            for (int qi = 0; qi < side; qi++)
            {
                for (int qj = 0; qj < side; qj++)
                {
                    if (qi == 0 && qj == 0)
                        continue;
                    if (qi == p[0] && qj == p[1])
                        continue;
                    int[] q = new int[] { qi, qj };
                    if (Check(p, q))
                        count ++;
                }
            }
            return count;
        }

        static bool Check(int[] p, int[] q)
        {
            int px = p[0];
            int py = p[1];
            int qx = q[0];
            int qy = q[1];
            if (px*qx + py*qy == 0)
                return true;
            if (px*px + py*py == (px*qx + py*qy))
                return true;
            if (qx*qx + qy*qy == (px*qx + py*qy))
                return true;
            return false;
        }
    }
}
