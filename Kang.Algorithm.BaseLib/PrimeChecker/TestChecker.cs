using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.PrimeChecker
{
    public class TestChecker
    {

        
        static long q = 1, p = 1;
        static long[] v;
        static long[] primes;
        static double markLen;
        static long count = 0;
        static long sum = 0, s = 0;
        static long i, j, m = 7;
        public static long PrimeCount(long num)
        {
            //throw new ApplicationException("计算3和125000数字时候报错，需要调查后续错误原因");
            q = 1;
            p = 1;
            markLen = 0;
            count = 0;
            sum = 0;
            s = 0;
            i = 0;
            j = 0;
            m = 7;
            markLen = num < 10000 ? 10002 : (long)(Math.Exp(2.0d / 3d * Math.Log(num)) + 1);
            bool[] marks = new bool[(long)markLen];


            // 筛选 n ^ (2/3) 或 n 以内的素数
            for (i = 2; i < (long)Math.Sqrt(markLen); i++)
            {
                if (marks[i])
                    continue;
                for (j = i + i; j < markLen; j += i)
                {
                    marks[j] = true;
                }
            }
            marks[0] = marks[1] = true;

            // 统计素数个数并保存素数
            List<long> primeList = new List<long>();
            for (i = 0; i < markLen; i++)
            {
                if (marks[i])
                    continue;
                count++;
                primeList.Add(i);
            }
            primes = primeList.ToArray();
            if (num < 10000)
                return Pi(num, primes, count);

            //n^(1/3)内的素数数目  
            long len = Pi((long)Math.Exp(1.0d / 3d * Math.Log(num)), primes, count);
            //n^(1/2)内的素数数目  
            long len2 = Pi((long)Math.Sqrt(num), primes, count);
            //n^（2/3)内的素数数目  
            long len3 = Pi((long)markLen - 1, primes, count);  

            // 乘积个数
            j = (long)markLen - 2;
            for (i = (long)Math.Exp(1.0d / 3d * Math.Log(num)); i < (long)Math.Sqrt(num); i++)
            {
                if (marks[i])
                    continue;
                while (i * j > num)
                {
                    if (!marks[j])
                        s++;
                    j--;
                }
                sum += s;
            }
            sum = (len2 - len) * len3 - sum;
            sum += (len * (len - 1) - len2 * (len2 - 1)) / 2;

            // 欧拉函数
            if (m > len)
                m = len;
            for (i = 0; i < m; i++)
            {
                q *= primes[i];
                p *= primes[i] - 1;
            }
            v = new long[q];
            for (i = 0; i < q; i++)
            {
                v[i] = i;
            }
            for (i = 0; i < m; i++)
            {
                for (j = q - 1; j >= 0; j--)
                {
                    v[j] -= v[j / primes[i]];
                }
            }

            sum = Phi(num, len, m) - sum + len - 1;
            return sum;

        }

        static long Pi(long n, long[] primeArr, long len)
        {
            long i = 0;
            bool mark = false;
            for (i = len - 1; i >= 0; i--)
            {
                if (primes[i] < n)
                {
                    mark = true;
                    break;
                }
            }
            if (mark)
                return i + 1;
            return 0;
        }

        private static long Phi(long x, long a, long m)
        {
            if (a == m)
                return (x / q) * p + v[x % q];
            if (x < primes[a - 1])
                return 1;
            return Phi(x, a - 1, m) - Phi((long)((double)x / (double)primes[a - 1]), a - 1, m);
        }
    }
}
