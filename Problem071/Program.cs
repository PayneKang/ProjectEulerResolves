using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using Kang.Algorithm.BaseLib;
using System.Numerics;

namespace Problem071
{
    class Program
    {
        const int MAXDIVIDEND = 1000000;
        static void Main(string[] args)
        {
            List<Fraction> fracList = new List<Fraction>();
            Fraction target = new Fraction(){ Divisor = 3, Dividend = 7};

            Fraction result = new Fraction() { Divisor = 1, Dividend = MAXDIVIDEND };
            for (int i = 2; i <= MAXDIVIDEND; i++)
            {
                Fraction frac = FindCloseTo(i, target);

                if (frac == null)
                    continue;
                //Console.WriteLine(string.Format("[{0}] - {1}", i, frac.ToString()));
                if (frac > result)
                {
                    result = frac;
                    //Console.WriteLine(string.Format("current close to 3/7 is {0}",result.ToString()));
                }

            }
            Console.WriteLine("Result is {0}", result.Divisor);
        
        
        }
        static Fraction FindCloseTo(int dividend, Fraction target)
        {
            int divisor = (dividend * target.Divisor - 1) / target.Dividend;
            return new Fraction() { Dividend = dividend, Divisor = divisor };
        }
    }
}
