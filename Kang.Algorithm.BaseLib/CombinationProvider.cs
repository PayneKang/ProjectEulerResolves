using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class CombinationProvider
    {
        private CombinationProvider() { }
        public static List<T[]> BuildCombination<T>(T[] seeds, int length)
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
                List<T[]> chdCombination = BuildCombination<T>(seeds, length - 1);
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
