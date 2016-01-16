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
        static List<List<int>> calculateResult = new List<List<int>>();
        static void Main(string[] args)
        {
            for (int i = 3; i <= 8; i++)
            {
                calculateResult.Add(CalculateAll4DigitNumber(i));
            }
            List<int> currNum = new List<int>(){calculateResult[0][0]};
            List<int> skipGroup = new List<int>() { 0 };
        }
        static bool FindAnotherNumber(List<int> currentNum, List<int> skipGroup)
        {
            if (found)
            {
                return true;
            }
            for (int i = 0; i < 6; i++)
            {
                if (skipGroup.Contains(i))
                    continue;
                for(int j = 0; j < calculateResult[i].Count; j++){
                    
                    bool findrlt = FindAnotherNumber(currentNum, skipGroup);
                    if (!findrlt)
                    {
                        continue;
                    }
                    if (currentNum.Count == MAX_LEN)
                    {
                        found = true;
                        return true;
                    }
                }
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
