using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Next()
        {
            secondNum = firstNum + secondNum;
            firstNum = secondNum - firstNum;
            return secondNum;
        }
        private LargeNumberModel firstLNum = new LargeNumberModel("1");
        private LargeNumberModel secondLNum = new LargeNumberModel("2");

        public LargeNumberModel NextLargeNumber()
        {
            LargeNumberModel temp = secondLNum;
            secondLNum = firstLNum + secondLNum;
            firstLNum = temp;
            return secondLNum;
        }
    }
}
