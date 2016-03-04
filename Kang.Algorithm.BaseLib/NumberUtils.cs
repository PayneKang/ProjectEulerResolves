using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class NumberUtils
    {
        public static int ToInt(string numStr)
        {
            return int.Parse(numStr.TrimStart(new char[] { '0' }));
        }
        /// <summary>
        /// 将数字分割成几个指定长度的数字
        /// </summary>
        /// <param name="number"></param>
        /// <param name="splitLength"></param>
        /// <returns></returns>
        public static int[] SplitNumber(long number,int splitLength)
        {
            int splitNumber = (int)Math.Pow(10,splitLength);
            List<int> result = new List<int>();
            long temp = number;
            while (temp > 0)
            {
                result.Add((int)(temp % splitNumber));
                temp = temp / splitNumber;
            }
            return result.ToArray();
        }
        public static int GetNumberLength(long number)
        {
            int length = 0;
            while (number > 0)
            {
                length++;
                number /= 10;
            }
            return length;
        }
    }
}
