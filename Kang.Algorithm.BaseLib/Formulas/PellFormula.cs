using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Kang.Algorithm.BaseLib.Formulas
{
    /// <summary>
    /// 用来对 x^2 - D * y ^ 2 = 1 进行求解的方法类
    /// </summary>
    public class PellFormula
    {
        public int D { get; private set; }
        public BigInteger[] CurrentResult { get; private set; }
        public BigInteger[] MinResult { get; private set; }
        /// <summary>
        /// 当前是第几个解，从 0 开始
        /// </summary>
        public int CurrentIndex { get; private set; }
        public PellFormula(int D)
        {
            this.D = D;
            this.CurrentIndex = 0;
        }
        private BigInteger N, p1, p2, q1, q2, a0, a1, a2, g1, g2, h1, h2, p, q;
        public BigInteger[] CalculateMinIntegerSolution()
        {
            g1 = q2 = p1= 0;
            h1 = q1 = p2 = 1;
            a0 = a1 = (int)Math.Sqrt(1.0 * this.D);
            BigInteger ans = a0 * a0;
            if (ans.Equals(this.D))
                throw new ApplicationException(string.Format("No solution for D {0}", this.D));
            N = this.D;
            while (true)
            {
                g2 = a1 * (h1) - g1;
                h2 = (N - (g2 * g2)) / h1;
                a2 = (g2 + a0) / h2;
                p = a1 * p2 + p1;
                q = a1 * q2 + q1;
                if ((p * p)-(N * (q * q))== 1) break;
                g1 = g2; h1 = h2; a1 = a2;
                p1 = p2; p2 = p;
                q1 = q2; q2 = q;  
            }
            this.CurrentIndex++;
            this.CurrentResult = new BigInteger[] { p, q };
            this.MinResult = new BigInteger[] { p, q };
            return this.MinResult;
        }
        public BigInteger[] FindNextSolution()
        {
            this.CurrentIndex++;
            BigInteger currP = this.CurrentResult[0] * this.MinResult[0] + this.D * this.CurrentResult[1] * this.MinResult[1];
            BigInteger currQ = this.CurrentResult[0] * this.MinResult[1] + this.CurrentResult[1] * this.MinResult[0];
            this.CurrentResult = new BigInteger[] { currP, currQ };
            return this.CurrentResult;
        }
    }
}
