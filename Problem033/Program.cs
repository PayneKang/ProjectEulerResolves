using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem033
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction temp = new Fraction()
            {
                Divisor = 49,
                Dividend = 98
            };
            List<Fraction> fracs = new List<Fraction>();
            for (int i = 10; i < 100; i++)
            {
                for (int j = i + 1; j < 100; j++)
                {
                    Fraction frac = new Fraction()
                    {
                         Divisor = i,
                          Dividend = j
                    };
                    fracs.Add(frac);
                }
            }
            List<Fraction> finalFracs = new List<Fraction>();
            foreach (Fraction frac in fracs)
            {
                if (CheckFrancCurious(frac))
                    finalFracs.Add(frac);
            }
            int divisor = 1, dividend = 1;
            foreach (Fraction frac in finalFracs)
            {
                divisor *= frac.Divisor;
                dividend *= frac.Dividend;
            }
            Fraction resultFrac = new Fraction() { Divisor = divisor, Dividend = dividend };
            Console.WriteLine(resultFrac.ToFinalFraction().Dividend);
        }
        static bool CheckFrancCurious(Fraction frac)
        {
            int divisorNum1 = frac.Divisor / 10;
            int divisorNum2 = frac.Divisor % 10;
            int dividendNum1 = frac.Dividend / 10;
            int dividendNum2 = frac.Dividend % 10;
            Fraction fracFinal = frac.ToFinalFraction();
            if (divisorNum1 == dividendNum1)
            {
                Fraction frac2 = new Fraction() { Dividend = dividendNum2, Divisor = divisorNum2 };
                Fraction frac2Final = frac2.ToFinalFraction();
                return fracFinal.Equals(frac2Final);
            }
            if (divisorNum1 == dividendNum2)
            {
                Fraction frac2 = new Fraction() { Dividend = dividendNum1, Divisor = divisorNum2 };
                Fraction frac2Final = frac2.ToFinalFraction();
                return fracFinal.Equals(frac2Final);
            }
            if (divisorNum2 == 0)
                return false;
            if (divisorNum2 == dividendNum1)
            {
                Fraction frac2 = new Fraction() { Dividend = dividendNum2, Divisor = divisorNum1 };
                Fraction frac2Final = frac2.ToFinalFraction();
                return fracFinal.Equals(frac2Final);
            }
            if (divisorNum2 == dividendNum2)
            {
                Fraction frac2 = new Fraction() { Dividend = dividendNum1, Divisor = divisorNum1 };
                Fraction frac2Final = frac2.ToFinalFraction();
                return fracFinal.Equals(frac2Final);
            }
            return false;
        }
    }
}
