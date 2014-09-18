using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem003
{
    class Program
    {
        /// <summary>
        /// 由于除数数量很少，没有逐个判断是否是prime
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            FactorsGenerator generator = new FactorsGenerator();
            List<long> factors = generator.GeneratorDistinctFactors(600851475143);
            foreach (long factor in factors)
            {
                Console.Write(factor + ",");
            }
            Console.ReadLine();
        }
    }
}
