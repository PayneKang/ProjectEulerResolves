using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Kang.Algorithm.BaseLib
{
    /// <summary>
    /// 斐波那契额数列生成器
    /// 每次生成下一个斐波那契数
    /// 从3开始
    /// </summary>
    public class FibonacciGenerator
    {
        public FibonacciGenerator(){}
        private int firstNum = 1;
        private int secondNum = 2;
        private double sqrt5 = Math.Sqrt(5);
        public int Next()
        {
            secondNum = firstNum + secondNum;
            firstNum = secondNum - firstNum;
            return secondNum;
        }
        private BigInteger firstLNum = 1;
        private BigInteger secondLNum = 2;

        public BigInteger NextLargeNumber()
        {
            BigInteger temp = secondLNum;
            secondLNum = firstLNum + secondLNum;
            firstLNum = temp;
            return secondLNum;
        }

        /// <summary>
        /// 直接返回第n个Fibonnaci数字，index从1开始
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public long GenerateFibonacci(long index)
        {
            return (long)((Math.Pow((1 + sqrt5) / 2, index) - Math.Pow((1 - sqrt5) / 2, index)) / sqrt5);
        }
    }
}
