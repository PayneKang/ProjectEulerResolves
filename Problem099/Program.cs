using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;

namespace Problem099
{
    class Program
    {
        static void Main(string[] args)
        {
            LargeNumberModel n = new LargeNumberModel("519432");
            for (int i = 1; i < 525806; i++)
            {
                n = n * 519432;
            }
        }
    }
}
