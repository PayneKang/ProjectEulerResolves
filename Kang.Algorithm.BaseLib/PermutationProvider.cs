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
            foreach (T item in seeds)
            {
                T[] chdSeeds = new T[seeds.Length - 1];
                for (int i = 0, j = 0; i < seeds.Length && j < chdSeeds.Length; i++)
                {
                    if (item.Equals(seeds[i]))
                        continue;
                    chdSeeds[j] = seeds[i];
                    j++;
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
