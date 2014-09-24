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
    }
}
