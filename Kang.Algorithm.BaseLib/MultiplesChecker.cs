using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    /// <summary>
    /// 检查一个数字是否是由给定的数求和得出
    /// </summary>
    public class MultiplesChecker
    {
        private MultiplesChecker() { }
        public MultiplesChecker(int product, int[] multipliers)
        {
            this.Product = product;
            this.Multipliers = multipliers;
        }
        public int Product { get; private set; }
        public int[] Multipliers { get; private set; }
        public bool Check()
        {
            int tempProduct = this.Product;
            foreach (int multiplier in Multipliers)
            {
                while (tempProduct % multiplier == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
