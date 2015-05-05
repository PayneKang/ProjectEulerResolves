using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class PermutationProvider
    {
        private PermutationProvider() { }
        public static List<T[]> BuildPermutation<T>(T[] seeds, int length)
        {
            List<T[]> result = new List<T[]>();
            if (length == 1)
            {
                foreach (T item in seeds)
                {
                    result.Add(new T[] { item });
                }
                return result;
            }
            for(int i = 0; i < seeds.Length; i++)
            {
                T item = seeds[i];
                T[] chdSeeds = new T[seeds.Length - 1];
                for (int j = 0, k = 0; j < seeds.Length && k < chdSeeds.Length; j++)
                {
                    if (j == i)
                        continue;
                    chdSeeds[k] = seeds[j];
                    k++;
                }
                List<T[]> chdCombination = BuildPermutation<T>(chdSeeds, length - 1);
                List<T[]> chdResult = new List<T[]>();
                foreach (T[] chdItem in chdCombination)
                {
                    T[] tempItem = new T[length];
                    chdItem.CopyTo(tempItem, 0);
                    tempItem[length - 1] = item;
                    chdResult.Add(tempItem);
                }
                result.AddRange(chdResult);
            }
            return result;
        }
    }
}
