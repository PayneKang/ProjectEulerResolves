using System.Diagnostics;
using Kang.Algorithm.BaseLib.PrimeChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Formulas;
using System.Numerics;

namespace Kang.Algorithm.BaseLib.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PellFormula pell = new PellFormula(92);
            BigInteger[] rlt = pell.CalculateMinIntegerSolution();
            BigInteger[] rlt2 = pell.FindNextSolution();
        }
    }
}
