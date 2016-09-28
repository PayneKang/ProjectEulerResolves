using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem066
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            BigInteger pMax = 0;
            for (int D = 2; D <= 1000; D++)
            {
                BigInteger limit = (int) Math.Sqrt(D);
                if (limit*limit == D) continue;
                BigInteger m = 0;
                BigInteger d = 1;
                BigInteger a = limit;

                BigInteger numm1 = 1;
                BigInteger num = a;

                BigInteger denm1 = 0;
                BigInteger den = 1;
                while (num*num - D*den*den != 1)
                {
                    m = d * a - m;
                    d = (D - m * m) / d;
                    a = (limit + m) / d;

                    BigInteger numm2 = numm1;
                    numm1 = num;
                    BigInteger denm2 = denm1;
                    denm1 = den;

                    num = a * numm1 + numm2;
                    den = a * denm1 + denm2;
                }
                if (num > pMax)
                {
                    pMax = num;
                    result = D;
                }
            }
        }
    }
}
