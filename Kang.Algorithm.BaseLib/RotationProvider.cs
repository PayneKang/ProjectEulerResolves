using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class RotationProvider
    {
        public static List<T[]> BuildRotations<T>(T[] seeds)
        {
            List<T[]> result = new List<T[]>();
            for (int i = 0; i < seeds.Length; i++)
            {
                T[] item = new T[seeds.Length];
                for (int k = 0; k < seeds.Length; k++)
                {
                    item[k] = seeds[(i + k) % seeds.Length];
                }
                result.Add(item);
            }
            return result;
        }
    }
}
