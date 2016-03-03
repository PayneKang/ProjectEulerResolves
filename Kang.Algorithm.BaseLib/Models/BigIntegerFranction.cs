using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Kang.Algorithm.BaseLib.Models
{
    public class BigIntegerFranction
    {
        /// <summary>
        ///  除数 分子
        /// </summary>
        public BigInteger Divisor { get; set; }
        /// <summary>
        /// 被除数 分母
        /// </summary>
        public BigInteger Dividend { get; set; }
        public BigIntegerFranction ToFinalFraction()
        {
            BigIntegerFranction temp = new BigIntegerFranction() { Divisor = this.Divisor, Dividend = this.Dividend };
            BigInteger min = temp.Dividend <= temp.Divisor? temp.Dividend:temp.Divisor;
            while (true)
            {
                if (min < 2)
                    break;
                if (temp.Divisor % min == 0 && temp.Dividend % min == 0)
                {
                    temp.Dividend = temp.Dividend / min;
                    temp.Divisor = temp.Divisor / min;
                    min = temp.Dividend <= temp.Divisor ? temp.Dividend : temp.Divisor;
                    continue;
                }
                min--;
                if (min < 2)
                    break;
                if (temp.Divisor % min == 0 && temp.Dividend % min == 0)
                {
                    temp.Dividend = temp.Dividend / min;
                    temp.Divisor = temp.Divisor / min;
                    min = temp.Dividend <= temp.Divisor ? temp.Dividend : temp.Divisor;
                    continue;
                }
            }
            return temp;
        }
    }
}
