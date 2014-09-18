using System;
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
    }
}
