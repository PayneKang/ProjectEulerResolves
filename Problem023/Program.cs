using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;
using Kang.Algorithm.BaseLib.Models;
using System.Diagnostics;

namespace Problem023
{
    class Program
    {
        const int MAXLENGTH = 28124;
        static void Main(string[] args)
        {
            bool[] numsequence = new bool[MAXLENGTH];
            List<long> abundantNumbers = findAllAbundantLessThan28123();
            for (int i = 0; i < abundantNumbers.Count; i++)
            {
                if (abundantNumbers[i] + abundantNumbers[i] >= MAXLENGTH)
                    break;
                for (int j = i; j < abundantNumbers.Count; j++)
                {
                    if (abundantNumbers[i] + abundantNumbers[j] < 28124)
                    {
                        numsequence[abundantNumbers[i] + abundantNumbers[j]] = true;
                    }
                    else
                        break;
                }
            }
            long result = 0;
            for (int i = 0; i < numsequence.Length; i++)
            {
                if (!numsequence[i])
                    result += i;
            }
            Console.WriteLine(result);
            Debug.WriteLine(result);
            Console.ReadLine();
        }
        static List<long> findAllAbundantLessThan28123()
        {
            FactorsGenerator fg = new FactorsGenerator();
            List<long> result = new List<long>();
            for (int i = 1; i < 28124; i++)
            {
                AbundantCheckNumber num = BuildAbundantCheckNumber(i, fg);
                if (num.NumberType == NumberType.Abundant)
                    result.Add(i);
            }
            return result;
        }
        static AbundantCheckNumber BuildAbundantCheckNumber(long value, FactorsGenerator fg)
        {
            List<long> divisors = fg.GeneratorDistinctDivisor(value);
            long sum = 0;
            foreach (long div in divisors)
            {
                if (div < value)
                    sum += div;
            }
            if (sum == value)
                return new AbundantCheckNumber() { Value = value, NumberType = NumberType.Perfect, DivisorsSum = sum };

            if (sum < value)
                return new AbundantCheckNumber() { Value = value, NumberType = NumberType.Deficient, DivisorsSum = sum };

            if (sum > value)
                return new AbundantCheckNumber() { Value = value, NumberType = NumberType.Abundant, DivisorsSum = sum };

            return new AbundantCheckNumber() { Value = value, NumberType = NumberType.NotChecked, DivisorsSum = sum };

        }
    }
}
