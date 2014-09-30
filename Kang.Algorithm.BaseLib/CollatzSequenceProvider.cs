using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class CollatzSequenceProvider
    {
        public long Start { get; private set; }
        private long currentNum;
        public CollatzSequenceProvider() { }
        public void setStartNum(long start)
        {
            this.Start = start;
        }
        public void DoBuildSequence()
        {

        }
        public int DoCalculateSequenceLength()
        {
            int length = 1;
            currentNum = this.Start;
            while (currentNum > 1)
            {
                currentNum = Arithmetic(currentNum);
                length++;
            }
            return length;
        }
        private long Arithmetic(long num)
        {
            if (num % 2 == 0)
                return num / 2;
            return 3 * num + 1;
        }
    }
}
