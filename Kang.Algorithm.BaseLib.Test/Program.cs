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
            QuadFormula qf = new QuadFormula(0, 0, 0, 10, 84, 16);
            qf.CalculateSolution();
        }
    }
}
