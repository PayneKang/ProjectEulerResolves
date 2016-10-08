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
            string str = FileReader.ReadFile(@"D:\primes.txt");
            string[] nums = str.Split(',');
            /*
            long bi = 2;
            int max = 100000000;
            bool[] mark = new bool[max + 1];
            PrimeGenerator pg = new PrimeGenerator();
            while (bi < max)
            {
                if (mark[bi])
                {
                    bi++;
                    continue;
                }
                //Console.WriteLine("Check prime {0}",bi);
                if (!pg.CheckPrime(bi))
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

            FileStream fs = File.Open(@"D:\primes.txt", FileMode.Create);
            for (int i = 2; i < max + 1; i++)
            {
                if (mark[i])
                    continue;

                byte[] buffer = Encoding.UTF8.GetBytes(string.Format("{0},", i));
                fs.Write(buffer, 0, buffer.Length);
                Console.WriteLine("{0}");
            }
            fs.Close();
            if (bi < 0)
            {
                throw new Exception("out of long range");
            }*/

        }
    }
}
