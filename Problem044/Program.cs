using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem044
{
    class Program
    {
        static int[] penNums = new int[3000];
        static void Main(string[] args)
        {
            int Min = int.MaxValue;
            BuildPenNums();
            List<int[]> penPairs = PermutationProvider.BuildPermutation<int>(penNums, 2);
            foreach (int[] penpair in penPairs)
            {
                int temp = Math.Abs(penpair[0] - penpair[1]);
                if (temp >= Min)
                    continue;
                if (!penNums.Contains(temp))
                    continue;
                int temp2 = penpair[0] + penpair[1];
                if (!penNums.Contains(temp2))
                    continue;                
                Min = temp;
            }
            Console.WriteLine("Result is {0}", Min);
        }
        static void BuildPenNums()
        {
            for(int i =0; i < 3000; i ++){
                penNums[i] = ((i + 1) * (3 * (i + 1) - 1)) / 2;
            }
        }
    }
}
