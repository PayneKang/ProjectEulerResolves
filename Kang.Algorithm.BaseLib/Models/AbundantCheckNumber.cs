using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.Models
{
    public enum NumberType
    {
        NotChecked,
        Deficient,
        Abundant,
        Perfect
    }
    public class AbundantCheckNumber
    {
        public NumberType NumberType { get; set; }
        public long Value { get; set; }
        public long DivisorsSum { get; set; }
    }
}
