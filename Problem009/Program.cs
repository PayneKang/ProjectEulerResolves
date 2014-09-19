using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem009
{
    public class NumberGroup
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }
        private NumberGroup() { }
        public NumberGroup(int a, int b, int c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }
        public bool CheckPythagoreanTriplet()
        {
            return A * A + B * B == C * C;
        }
        public int Product()
        {
            return A * B * C;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<NumberGroup> grp = new List<NumberGroup>();
            for (int a = 1; a < 500; a++)
            {
                for (int b = a + 1; b < 1000 - a - b; b++)
                {
                    int c = 1000 - a - b;
                    NumberGroup ng = new NumberGroup(a,b,c);
                    if (ng.CheckPythagoreanTriplet())
                    {
                        Console.WriteLine(ng.Product());
                        Console.Read();
                        return;
                    }
                }
            }
        }
    }
}
