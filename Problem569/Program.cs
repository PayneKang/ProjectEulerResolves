using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem569
{
    class Program
    {
        class Mountain
        {
            public long Height { get; set; }
            public long Distance { get; set; }
            public List<int> CoveredIndex { get; set; }
        }
        static List<Mountain> mountains = new List<Mountain>();
        const int MountainCount = 2500000;
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string[] str = FileReader.ReadFile("primes_100000000.txt").Split(',');
            int[] primes = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                primes[i] = int.Parse(str[i]);
            }
            int depth = 0;
            long distance = 0;
            for (int i = 0; i < MountainCount * 2; i++)
            {
                if (i % 2 == 0)
                {
                    depth = depth + primes[i];
                    distance = distance + primes[i];
                    mountains.Add(new Mountain() { CoveredIndex = new List<int>(), Distance = distance, Height = depth });
                    continue;
                }
                depth = depth - primes[i];
                distance = distance + primes[i];
            }
            int sum = 0;
            FileStream fs = File.Open(@"D:\Problem569.txt", FileMode.OpenOrCreate);
            for (int k = MountainCount; k >= 1; k--)
            {
                int pk = P(k);
                sum += pk;
                byte[] buffer = Encoding.UTF8.GetBytes(string.Format("\r\n{0}:{1}", k, pk));
                fs.Write(buffer,0,buffer.Length);
            }
            fs.Close();
            sw.Stop();
            FileStream fs2 = File.Open(@"D:\Problem569_Result.txt", FileMode.OpenOrCreate);
            string result = string.Format("\r\nResult is {0},timeused {1} days {2} hours {3} minutes {4} seconds {5} ms", sum, sw.Elapsed.Days, sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            byte[] buffer2 = Encoding.UTF8.GetBytes(result);
            fs2.Write(buffer2, 0, buffer2.Length);
            fs2.Close();
        }
        static int P(int k)
        {
            if(k == 1)
                return 0;
            if (k == 2)
            {
                mountains[1].CoveredIndex.Add(0);
                return 1;
            }
            double mintag = 1;
            double tag = 1;
            Mountain currMountain = mountains[k - 1];
            int count = 0;
            for (int i = k - 2; i >= 0; i--)
            {
                long deltaHeight = currMountain.Height - mountains[i].Height;
                long deltaDistance = currMountain.Distance - mountains[i].Distance;
                tag = (double)deltaHeight / (double)deltaDistance;
                if (tag < mintag)
                {
                    count++;
                    mintag = tag;
                    continue;
                }

            }
            return count;
        }
    }
}
