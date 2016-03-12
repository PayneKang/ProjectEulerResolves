using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem051
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeGenerator pg = new PrimeGenerator();
            int[] primes = pg.GetPrimesBelowOneMillion();
            bool[] primeMark = pg.CheckPrimeNumber(1000000);
            for (int i = 0; i < primes.Length; i++)
            {
                int prime = primes[i];
                int[] digits = NumberUtils.SplitNumber(prime,1);
                for (int mark = 1; mark < ((1 << digits.Length) -  1); mark++)
                {
                    int primeCount = 0;
                    for (int n = 0; n < 10; n++)
                    {
                        int[] markedDigits = ChangeMarkedDigits(digits, mark, n);
                        if (markedDigits[0] % 2 == 0 || markedDigits[0] % 5 == 0)
                            continue;
                        if (markedDigits[digits.Length - 1] == 0)
                            continue;
                        int num = MarkDigitsToNumber(markedDigits);
                        if (!primeMark[num])
                            continue;
                        primeCount++;
                    }
                    if (primeCount == 8)
                    {
                        int result = int.MaxValue;
                        for (int n = 0; n < 10; n++)
                        {
                            int[] markedDigits = ChangeMarkedDigits(digits, mark, n);
                            if (markedDigits[0] % 2 == 0 || markedDigits[0] % 5 == 0)
                                continue;
                            if (markedDigits[digits.Length - 1] == 0)
                                continue;
                            int num = MarkDigitsToNumber(markedDigits);
                            if (!primeMark[num])
                                continue;
                            if (num < result)
                                result = num;
                        }
                        Console.WriteLine("Result is {0}", result);
                        return;
                    }
                    //Console.WriteLine(Convert.ToString(mark, 2));
                }
            }
        }
        static int MarkDigitsToNumber(int[] digits)
        {
            int result = 0;
            int multiplicator = 1;
            for (int i = 0; i < digits.Length; i++)
            {
                result += digits[i] * multiplicator;
                multiplicator *= 10;
            }
            return result;
        }
        static int[] ChangeMarkedDigits(int[] digits, int mark, int n)
        {
            int[] temp = new int[digits.Length];
            digits.CopyTo(temp, 0);
            for (int i = 0; i < temp.Length; i++)
            {
                if (mark % 2 == 1)
                {
                    temp[i] = n;
                }
                mark = mark >> 1;
            }
            return temp;
        }
    }
}
