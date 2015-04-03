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
        const int MAXLENGTH = 28123;
        static void Main(string[] args)
        {
            GetResult();
        }
        static void GetResult()
        {
            bool[] numsequence = new bool[MAXLENGTH + 1];
            List<long> abundantNumbers = findAllAbundantLessThan28123();

            for (int i = 0; i < abundantNumbers.Count; i++)
            {
                if (abundantNumbers[i] + abundantNumbers[i] > MAXLENGTH)
                    break;
                for (int j = i; j < abundantNumbers.Count; j++)
                {
                    if (abundantNumbers[i] + abundantNumbers[j] <= MAXLENGTH)
                    {
                        numsequence[abundantNumbers[i] + abundantNumbers[j]] = true;
                    }
                    else
                        break;
                }
            }
            long result = 0;
            for (int i = 0; i < MAXLENGTH; i++)
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
            for (int i = 1; i < MAXLENGTH; i++)
            {
                if (i == 28123)
                    Console.WriteLine();
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
