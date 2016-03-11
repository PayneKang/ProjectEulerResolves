using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Numerics;

namespace Problem104
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger rightA = 1;
            BigInteger rightB = 1;
            BigInteger firstA = 1;
            BigInteger firstB = 1;
            int i = 3;
            while (true)
            {
                BigInteger temp = rightA;
                rightA = rightB;
                rightB = temp + rightB;
                Console.WriteLine(rightB);
                //if (rightB >= 1000000000)
                //    rightB = rightB % 1000000000;
                //temp = firstA;
                //firstA = firstB;
                //firstB = temp + firstA;
                //IEnumerable<char> lastNineDigits = rightB.ToString().ToArray();
                //if (lastNineDigits.Where(x => x != 0).Distinct().Count() == 9)
                //{
                //    break;
                //}
                i++;
            }
        }
    }
}
