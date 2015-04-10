using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.Models
{
    public class Fraction
    {
        public int Divisor { get; set; }
        public int Dividend { get; set; }
        public double GetValue()
        {
            return (double)Divisor / (double)Dividend;
        }
        public override string ToString()
        {
            return string.Format("{0}/{1}",Divisor,Dividend);
        }
        public override bool Equals(object obj)
        {
            return (this.Dividend == ((Fraction)obj).Dividend && this.Divisor == ((Fraction)obj).Divisor);
        }
        public Fraction ToFinalFraction()
        {
            Fraction temp = new Fraction() { Divisor = this.Divisor, Dividend = this.Dividend };
            int min = Math.Min(temp.Dividend, temp.Divisor);
            while (true)
            {
                if (min < 2)
                    break;
                if (temp.Divisor % min == 0 && temp.Dividend % min == 0)
                {
                    temp.Dividend = temp.Dividend / min;
                    temp.Divisor = temp.Divisor / min;
                    min = Math.Min(temp.Dividend, temp.Divisor);
                    continue;
                }
                min--;
                if (min < 2)
                    break;
                if (temp.Divisor % min == 0 && temp.Dividend % min == 0)
                {
                    temp.Dividend = temp.Dividend / min;
                    temp.Divisor = temp.Divisor / min;
                    min = Math.Min(temp.Dividend, temp.Divisor);
                    continue;
                }
            }
            return temp;
        }
    }
}
