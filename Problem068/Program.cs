using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem068
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> intsList =
                Kang.Algorithm.BaseLib.PermutationProvider.BuildPermutation<int>(
                    new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 10);
            long max = 0;
            foreach (int[] ints in intsList)
            {
                if(ints[0] > 6)
                    continue;

                if(ints[0] > ints[3] || ints[0] > ints[5] || ints[0] > ints[7] || ints[0] > ints[9])
                    continue;

                int sum = ints[0] + ints[1] + ints[2];

                if (ints[3] + ints[2] + ints[4] != sum)
                    continue;
                if (ints[5] + ints[4] + ints[6] != sum)
                    continue;
                if (ints[7] + ints[6] + ints[8] != sum)
                    continue;
                if (ints[9] + ints[8] + ints[1] != sum)
                    continue;

                if(ints[1] == 10 || ints[2] == 10 || ints[4] == 10 || ints[6] == 10 || ints[8] == 10)
                    continue;

                string result = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}"
                    , ints[0], ints[1], ints[2], ints[3], ints[2], ints[4], ints[5], ints[4], ints[6], ints[7], ints[6],
                    ints[8], ints[9], ints[8], ints[1]);
                long lr = long.Parse(result);
                if (lr > max)
                {
                    max = lr;
                }
            }
            Console.WriteLine("result is {0}",max);
        }
    }
}
