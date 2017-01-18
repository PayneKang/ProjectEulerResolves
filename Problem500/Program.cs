using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem500
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> c = new Dictionary<int, List<int>>();
            FactorsGenerator fg = new FactorsGenerator();
            for (int i = 1; i < 500; i++)
            {
                int count = fg.GeneratorDistinctDivisor(i).Count;
                if (!c.ContainsKey(count))
                {
                    c.Add(count, new List<int>());
                }
                c[count].Add(i);
                continue;
            }

        }
    }
}
