using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace PrimeBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            long bi = 2;
            int max = 1000000000;
            bool[] mark = new bool[max + 1];
            mark[0] = true;
            mark[1] = true;
            PrimeGenerator pg = new PrimeGenerator();
            while (bi < max)
            {
                if (mark[bi])
                {
                    bi++;
                    continue;
                }
                long start = bi * 2;
                for (long i = start; i <= max; i += bi)
                {
                    mark[i] = true;
                }
                bi++;
            }
            int count = mark.Count(x => x == false);
            StringBuilder sb = new StringBuilder("2");
            for (int i = 3; i < max + 1; i++)
            {
                if (mark[i])
                    continue;
                sb.Append(string.Format(",{0}", i));
            }
            FileStream fs = File.Open(@"D:\primes.txt", FileMode.Create);
            byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());
            fs.Write(buffer, 0, buffer.Length);            
            fs.Close();

        }
    }
}
