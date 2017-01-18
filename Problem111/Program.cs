using Kang.Algorithm.BaseLib;
using Kang.Algorithm.BaseLib.PrimeChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem111
{
    public class NumberGenerator
    {
        public int NumberLength { get; set; }
        public int[] ReplacedDigits { get; set; }
        public int OrgNumber { get; set; }
        public bool[] GenerateDigits { get; set; }
        public long currNum { get; set; }
        public long maxNum { get; set; }
        public NumberGenerator(int numberLength, int[] replacedDigits, int orgNumber)
        {
            if (orgNumber < 0 || orgNumber > 9)
            {
                throw new Exception("Org number must between 0 and 9");
            }
            this.NumberLength = numberLength;
            this.ReplacedDigits = replacedDigits;
            this.OrgNumber = orgNumber;
            this.GenerateDigits = new bool[NumberLength];
            currNum = (long)Math.Pow(10, this.NumberLength - replacedDigits.Length -1);
            maxNum = (long)Math.Pow(10, this.NumberLength - replacedDigits.Length);
            foreach (int digit in ReplacedDigits)
            {
                this.GenerateDigits[digit] = true;
            }
        }
        public long NextNumber()
        {
            if (currNum < 0)
                throw new Exception("out of range Error");
            if (currNum > maxNum)
                return -1;
            long temp = currNum;
            long rlt = 0;
            long c = maxNum / 10;
            for (int i = 0; i < this.NumberLength; i++)
            {
                rlt *= 10;
                if (this.GenerateDigits[i])
                {
                    rlt += this.OrgNumber;
                    continue;
                }
                rlt += (temp / c) % 10;
                c /= 10;
            }
            this.currNum++;
            return rlt;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            long sum = 0;
            for (int i = 0; i < 10; i++)
            {
                long rlt = M(n, i);
                Console.Write("M({2},{0}) = {1} \t", i, rlt,n);
                long rlt1 = N(n, i);
                Console.Write("N({2},{0}) = {1} \t", i, rlt1,n);
                long rlt2 = S(n, i);
                Console.WriteLine("S({2},{0}) = {1}", i, rlt2,n);
                sum += rlt2;
            }
            Console.WriteLine("Sum of S({0},d) is {1}", n, sum);
        }
        static long S(int digitLength, int targetNum)
        {
            int m = M(digitLength, targetNum);
            int[] digitsIndex = new int[digitLength];
            for (int i = 0; i < digitLength; i++)
            {
                digitsIndex[i] = i;
            }
            List<int[]> digitsGroup = CombinationProvider.BuildDistinctCombination<int>(digitsIndex, m);
            long s = 0;
            int primeCount = 0;
            foreach (int[] digits in digitsGroup)
            {
                // 逐个创建对应的数字，如果数字为素数，则返回对应的i；
                if (digits.Contains(0) && 0 == targetNum)
                {
                    continue;
                }
                NumberGenerator ng = new NumberGenerator(digitLength, digits, targetNum);
                long num = ng.NextNumber();
                while (num != -1)
                {
                    if (MillerRabinCheck.isPseudoPrime(num))
                    {
                        s += num;
                        primeCount++;
                    }
                    num = ng.NextNumber();
                }
            }
            return s;
        }
        static int N(int digitLength, int targetNum)
        {
            int m = M(digitLength, targetNum);
            int[] digitsIndex = new int[digitLength];
            for (int i = 0; i < digitLength; i++)
            {
                digitsIndex[i] = i;
            }
            List<int[]> digitsGroup = CombinationProvider.BuildDistinctCombination<int>(digitsIndex, m);
            int primeCount = 0;
            foreach (int[] digits in digitsGroup)
            {
                // 逐个创建对应的数字，如果数字为素数，则返回对应的i；
                if (digits.Contains(0) && 0 == targetNum)
                {
                    continue;
                }
                NumberGenerator ng = new NumberGenerator(digitLength, digits, targetNum);
                long num = ng.NextNumber();
                while (num != -1)
                {
                    if (MillerRabinCheck.isPseudoPrime(num))
                    {
                        primeCount++;
                    }
                    num = ng.NextNumber();
                }
            }
            return primeCount;
        }
        static int M(int digitLength, int targetNum)
        {
            int[] digitsIndex = new int[digitLength];
            for (int i = 0; i < digitLength; i++)
            {
                digitsIndex[i] = i;
            }
            for(int currLen = digitLength - 1; currLen>0; currLen--){
                List<int[]> digitsGroup = CombinationProvider.BuildDistinctCombination<int>(digitsIndex, currLen);
                foreach (int[] digits in digitsGroup)
                {
                    // 逐个创建对应的数字，如果数字为素数，则返回对应的i；
                    if (digits.Contains(0) && 0 == targetNum)
                    {
                        continue;
                    }
                    NumberGenerator ng = new NumberGenerator(digitLength, digits, targetNum);
                    long num = ng.NextNumber();
                    while (num != -1)
                    {
                        if (MillerRabinCheck.isPseudoPrime(num))
                            return currLen;
                        num = ng.NextNumber();
                    }
                }
            };
            return 0;
        }
        

    }
}
