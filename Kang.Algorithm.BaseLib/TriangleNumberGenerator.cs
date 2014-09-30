using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class TriangleNumberGenerator
    {
        public long CurrentNumber { get; private set; }
        public long CurrentTriangle { get; private set; }
        public TriangleNumberGenerator()
        {
            this.CurrentNumber = 0;
        }
        public long Next()
        {
            this.CurrentNumber++;
            this.CurrentTriangle += this.CurrentNumber;
            return this.CurrentTriangle;
        }
    }
}
