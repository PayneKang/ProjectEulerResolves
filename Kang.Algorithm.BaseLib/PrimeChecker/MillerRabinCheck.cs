using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Kang.Algorithm.BaseLib.PrimeChecker
{
    /// <summary>
    /// 使用Miller Rabin算法来构建的素数算法
    /// 是一种概率素数测试算法
    /// </summary>
    public class MillerRabinCheck
    {
        private static long[] Range;
        private static long MaxRange ;
        private static int[][] Seeds;
        static MillerRabinCheck()
        {
            Range = new long[] { 2047, 1373653, 9080191, 25326001, 3215031751, 4759123141, 1122004669633, 2152302898747, 3474749660383, 341550071728321, 3825123056546413051 };
            MaxRange = Range.Max();
            Seeds = new int[][]{ 
                new int[]{2},
                new int[]{2,3},
                new int[]{31,73},
                new int[]{2,3,5},
                new int[]{2,3,5,7},
                new int[]{2,7,61},
                new int[]{2,13,23,1662803},
                new int[]{2,3,5,7,11},
                new int[]{2,3,5,7,11,13},
                new int[]{2,3,5,7,11,13,17},
                new int[]{2,3,5,7,11,13,17,19,23}
            };
        }
        /// <summary>
        /// 判断一个数是否是素数（概率算法，有极小几率将合数判断为素数）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool isPseudoPrime(long n)
        {
            if (n >= MaxRange)
            {
                throw new Exception("Out of prime check range");
            }
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            if (n < 9) return true;
            if (n % 3 == 0) return false;
            if (n % 5 == 0) return false;

            int[] ar = findSeeds(n);
            for (int i = 0; i < ar.Length; i++)
            {
                if (Witness(ar[i], n)) return false;
            }
            return true;
            
        }
        private static int[] findSeeds(long n)
        {
            int index = 0;
            for (; index < Range.Length; index++)
            {
                if (n >= Range[index])
                    continue;
                break;
            }
            return Seeds[index];
        }
        private static bool Witness(int a, BigInteger n)
        {
            int t = 0;
            BigInteger u = n - 1;
            while ((u & 1) == 0)
            {
                t++;
                u >>= 1;
            }

            BigInteger xi1 = BigInteger.ModPow(a, u, n);
            BigInteger xi2;

            for (int i = 0; i < t; i++)
            {
                xi2 = xi1 * xi1 % n;
                if ((xi2 == 1) && (xi1 != 1) && (xi1 != (n - 1)))
                    return true;
                xi1 = xi2;
            }
            if (xi1 != 1)
                return true;
            return false;
        }
    }
}
