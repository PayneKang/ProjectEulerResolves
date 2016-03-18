using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem061
{
    class Program
    {
        const int MAX_LEN = 3;
        static bool found = false;
        static List<int>[] calculateResult = new List<int>[9];
        static void Main(string[] args)
        {
            for (int i = 3; i <= 8; i++)
            {
                calculateResult[i] = CalculateAll4DigitNumber(i);
            }
        }
        static List<int> CalculateAll4DigitNumber(int seed)
        {
            List<int> result = new List<int>();
            for (int i = 1; ; i++)
            {
                int rlt = CalculateFormula(seed, i);
                if (rlt < 1000)
                    continue;
                if (rlt >= 10000)
                    return result;
                result.Add(rlt);
            }
        }
        static int CalculateFormula(int seed, int num)
        {
            switch (seed)
            {
                case 3:
                    return Triangle(num);
                case 4:
                    return Square(num);
                case 5:
                    return Pentagonal(num);
                case 6:
                    return Hexagonal(num);
                case 7:
                    return Heptagonal(num);
                case 8:
                    return Octagonal(num);
                default:
                    throw new Exception("seed must be from 3 to 8");
            }
        }
        static int Triangle(int n)
        {
            return n * (n + 1) / 2;
        }
        static int Square(int n)
        {
            return n * n;
        }
        static int Pentagonal(int n)
        {
            return n * (3 * n - 1) / 2;
        }
        static int Hexagonal(int n)
        {
            return n * (2 * n - 1);
        }
        static int Heptagonal(int n)
        {
            return n * ( 5 * n - 3 ) / 2;
        }
        static int Octagonal(int n)
        {
            return n * (3 * n - 2);
        }
    }
}
