using Kang.Algorithm.BaseLib.PrimeChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem146
{
    class Program
    {
        static void Main(string[] args)
        {
            
            long limit = 150000000;
            long result = 0;

            for (long i = 10; i <= limit; i += 10)
            {

                long squared = i * i;

                if (squared % 3 != 1) continue;
                if (squared % 7 != 2 && squared % 7 != 3) continue;

                if (squared % 9 == 0 ||
                    squared % 13 == 0 ||
                    squared % 27 == 0)
                    continue;

                if (MillerRabinCheck.isPseudoPrime(squared + 1) &&
                    MillerRabinCheck.isPseudoPrime(squared + 3) &&
                    MillerRabinCheck.isPseudoPrime(squared + 7) &&
                    MillerRabinCheck.isPseudoPrime(squared + 9) &&
                    MillerRabinCheck.isPseudoPrime(squared + 13) &&
                    MillerRabinCheck.isPseudoPrime(squared + 27) &&
                   !MillerRabinCheck.isPseudoPrime(squared + 19) &&
                   !MillerRabinCheck.isPseudoPrime(squared + 21))
                    result += i;

            }
            Console.WriteLine("Result is {0}", result);
        }
    }
}
