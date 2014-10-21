using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem026
{
    public class DecimalRepresentation
    {
        private DecimalRepresentation() { }
        public DecimalRepresentation(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public List<int> RepresentationNumber { get; private set; }
        public bool IsLoop { get; private set; }
        public int Length { get; private set; }
        private List<int> Remainder;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in RepresentationNumber)
            {
                sb.Append(i);
            }
            return sb.ToString();
        }
        public void Calculate()
        {
            RepresentationNumber = new List<int>();
            Remainder = new List<int>();
            Length = 0;
            do
            {
                if (Numerator < Denominator)
                {
                    RepresentationNumber.Add(0);
                    Numerator = Numerator * 10;
                    Remainder.Add(Numerator);
                    Length++;
                    continue;
                }
                RepresentationNumber.Add(Numerator / Denominator);
                int remainder = Numerator % Denominator;
                Numerator = remainder * 10;
                if (Numerator == 0)
                {
                    IsLoop = false;
                    Length++;
                    return;
                }
                if (LoopStart(Numerator) >= 0)
                {
                    IsLoop = true;
                    Length -= LoopStart(Numerator);
                    return;
                }
                Length++;
                Remainder.Add(Numerator);
                continue;
            } while (true);
        }
        private int LoopStart(int remainder)
        {
            if (Remainder.Contains(remainder))
                return Remainder.IndexOf(remainder);
            return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int maxL = 0;
            DecimalRepresentation maxDr = new DecimalRepresentation(1,2);
            for (int i = 2; i <= 1000; i++)
            {
                DecimalRepresentation dr = new DecimalRepresentation(1,i);
                dr.Calculate();
                if (!dr.IsLoop)
                    continue;
                if (dr.Length > maxL)
                {
                    maxL = dr.Length;
                    maxDr = dr;
                }
            }
            Console.WriteLine(maxDr.Denominator);
            Console.ReadLine();
        }
    }
}
