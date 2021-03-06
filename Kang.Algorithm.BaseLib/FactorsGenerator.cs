﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    /// <summary>
    /// 乘数生成器
    /// 
    /// 给定一个数字，返回这个数字所有的乘数，剔除重复数字
    /// </summary>
    public class FactorsGenerator
    {
        private Dictionary<long, List<long>> dicDistinctFacotors;
        private int[] primes;
        public FactorsGenerator()
        {
            this.primes = new PrimeGenerator().GetPrimesBelowOneMillion();
            this.dicDistinctFacotors = new Dictionary<long, List<long>>();
        }
        public List<long> GeneratorDistinctDivisor(long number)
        {
            List<long> result = new List<long>();
            double sqrt = Math.Sqrt(number);
            long lsqrt = 0;
            lsqrt = (long)sqrt;
            for (long i = lsqrt; i > 0; i--)
            {
                if (number % i == 0)
                {
                    result.Add(i);
                    long di = number / i;
                    if( i != di)
                        result.Add(number/i);
                }
            }
            return result;
        }
        public int GeneratorDistinctDivisorCount(long number)
        {
            int result = 0;
            double sqrt = Math.Sqrt(number);
            long lsqrt = 0;
            bool sp = false;
            lsqrt = (long)sqrt;
            if (sqrt - (long)sqrt == 0)
            {
                sp = true;
            }
            for (long i = lsqrt; i > 0; i--)
            {
                if (number % i == 0)
                {
                    result++;
                    if (!sp)
                        result++;
                }
            }
            return result;
        }
        public List<long> GeneratorDistinctFactors(long number)
        {
            long tempNumber = number;
            List<long> result = new List<long>();
            for (long i = 2; i <= tempNumber; i++)
            {
                if (tempNumber == 1)
                {
                    break;
                }
                if (tempNumber % i == 0)
                {
                    result.Add(i);
                }
                while (tempNumber % i == 0)
                {
                    tempNumber = tempNumber / i;
                }
            }
            return result;
        }
        public List<int> GeneratorDistinctFactors(int number)
        {
            int tempNumber = number;
            List<int> result = new List<int>();
            for (int i = 2; i <= tempNumber; i++)
            {
                if (tempNumber == 1)
                {
                    break;
                }
                if (tempNumber % i == 0)
                {
                    result.Add(i);
                }
                while (tempNumber % i == 0)
                {
                    tempNumber = tempNumber / i;
                }
            }
            return result;
        }
        /// <summary>
        /// 获取一个数的质因数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<long> GeneratorFactors(long number)
        {
            long tempNumber = number;
            List<long> result = new List<long>();
            for (long i = 2; i <= tempNumber; i++)
            {
                if (tempNumber == 1)
                {
                    break;
                }
                while (tempNumber % i == 0)
                {
                    result.Add(i);
                    tempNumber = tempNumber / i;
                }
            }
            return result;
        }
        public List<int> GeneratorFactorsBelowOneMillion(int number)
        {
            long tempNumber = number;
            List<int> result = new List<int>();
            foreach (int p in primes)
            {
                if (p > tempNumber)
                    break;
                if (tempNumber == 1)
                {
                    break;
                }
                while (tempNumber % p == 0)
                {
                    result.Add(p);
                    tempNumber = tempNumber / p;
                }

            }
            return result;
        }
    }
}
