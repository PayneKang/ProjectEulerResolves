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
        public static long CountCombination(int seedsCount, int length,long maxVal,out bool outOfMaxVal)
        {
            outOfMaxVal = false;
            FactorsGenerator fg = new FactorsGenerator();
            List<long> pn = new List<long>();
            for (int a = 1; a <= seedsCount; a++)
            {
                pn.AddRange(fg.GeneratorFactors(a));
            }
            List<long> pm = new List<long>();
            for (int a = 1; a <= length; a++)
            {
                pm.AddRange(fg.GeneratorFactors(a));
            }
            for (int a = 1; a <= seedsCount - length; a++)
            {
                pm.AddRange(fg.GeneratorFactors(a));
            }
            List<long> pm2 = new List<long>();
            foreach (long a in pm)
            {
                if (pn.Contains(a))
                {
                    pn.Remove(a);
                    continue;
                }
                pm2.Add(a);
            }
            long result = 1;
            int j = 0;
            foreach (long a in pn)
            {
                result *= a;
                if (result >= maxVal)
                {
                    outOfMaxVal = true;
                    if(j < pm2.Count){
                        result /= pm2[j];
                        j++;
                    }
                    if( j >= pm2.Count){
                        break;
                    }
                }
            }
            
            for (; j < pm2.Count; j++ )
            {
                result /= pm2[j];
            }
            return result;
        }
    }
}
