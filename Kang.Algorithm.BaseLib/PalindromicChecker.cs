using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    /// <summary>
    /// 检查一个数翻转后是否等于原数字
    /// </summary>
    public class PalindromicChecker
    {
        public int Revert(int num)
        {
            int tempNum = num;
            int revertNum = 0;
            while (tempNum > 0)
            {
                int modNum = tempNum % 10;
                tempNum = tempNum / 10;
                revertNum = revertNum * 10 + modNum;
            }
            return revertNum;
        }
        public bool Check(int num)
        {
            return Revert(num) == num;
        }
    }
}
