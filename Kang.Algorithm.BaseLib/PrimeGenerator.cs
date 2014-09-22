using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Kang.Algorithm.BaseLib
{
    public class PrimeGenerator
    {
        private static int[] primes;
        static PrimeGenerator()
        {
            string primeStr = FileReader.ReadFile("Primes.txt");
            string[] primeArray = primeStr.Split(',');
            primes = new int[primeArray.Length];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = int.Parse(primeArray[i]);
            }
        }
        public bool CheckPrime(int number)
        {
            if (number <= 1000000)
                return FoundInPrimes(number);
            return CheckPrimeOver1000000(number);
        }
        private bool FoundInPrimes(int number){
            return primes.Contains(number);
        }
        private bool CheckPrimeOver1000000(int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            sqrt ++;
            for (int i = 3; i <= sqrt; i ++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        public bool[] CheckPrimeNumber(int length)
        {
            bool[] numbers = new bool[length + 1];
            for (int i = 2; i < numbers.Length; i++)
            {
                numbers[i] = true;
            }
            for (int i = 2; i <= length; i++)
            {
                for (int m = i; m <= length; m += i )
                {
                    if (m % i == 0 && m != i)
                    {
                        numbers[m] = false;
                    }
                }
            }
            return numbers;
        }
    }
}
