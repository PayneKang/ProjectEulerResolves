<<<<<<< .mine
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem061
{
    public class NumberModel{
        public int NumberValue { get; set; }
        public List<NumberModel> NextNumber { get; set; }
    }    
    class Program
    {
        static List<int> BuildFormulaNumbers(Func<int, int> func)
        {
            List<int> result = new List<int>();
            // Triangle
            int rlt = 0;
            int i = 1;
            while (rlt < 10000)
            {
                rlt = func(i);
                i++;
                if (rlt < 1000)
                    continue;
                if (rlt >= 10000)
                    break;
                if (!result.Contains(rlt))
                    result.Add(rlt);
            }
            return result;
        }
        static List<int> BuildNumbers()
        {
            List<int> result = new List<int>();
            result.AddRange(BuildFormulaNumbers(Triangle));
            result.AddRange(BuildFormulaNumbers(Square));
            result.AddRange(BuildFormulaNumbers(Pentagonal));
            result.AddRange(BuildFormulaNumbers(Hexagonal));
            result.AddRange(BuildFormulaNumbers(Heptagonal));
            result.AddRange(BuildFormulaNumbers(Octagonal));
            return result;
        }
        static void Main(string[] args)
        {
            List<int> numbers = BuildNumbers();
            List<NumberModel> nms = new List<NumberModel>();
            foreach (int num in numbers)
            {
                nms.Add(new NumberModel() { NextNumber = new List<NumberModel>(), NumberValue = num });
            }
            int len = 0;
            while (len < 4)
            {
                if (len == 0)
                {
                    for (int i = 0; i < nms.Count; i++)
                    {
                        for (int j = 0; j < nms.Count; j++)
                        {
                            if (nms[i].NumberValue % 100 != nms[j].NumberValue / 100)
                                continue;
                            if (nms[i].NextNumber.Contains(nms[j]))
                                continue;
                            nms[i].NextNumber.Add(nms[j]);
                        }
                    }
                    len++;
                    continue;
                }
                for (int i = 0; i < nms.Count; i++)
                {
                    for (int j = 0; j < nms.Count; j++)
                    {
                        if (nms[i].NextNumber.LastOrDefault().NumberValue % 100 != nms[j].NumberValue / 100)
                            continue;
                        if (nms[i].NextNumber.Contains(nms[j]))
                            continue;
                        nms[i].NextNumber.Add(nms[j]);
                    }
                }
                len++;
            }
        }
        static List<List<NumberModel>> CheckNextNumber(NumberModel current, int currentLen, NumberModel startNum, bool checkend)
        {
            if (checkend)
            {
                foreach (NumberModel nm in current.NextNumber)
                {
                    if (nm.NumberValue % 100 == startNum.NumberValue / 100)
                    {
                        return new List<List<NumberModel>>() { new List<NumberModel>() { nm } };
                    }
                }
                return null;
            }
            foreach (NumberModel nm in current.NextNumber)
            {
                bool checknext = false;
                if (currentLen == 1)
                    checknext = true;
                List<List<NumberModel>> next = CheckNextNumber(nm, currentLen - 1, startNum, checknext);
                foreach(List<NumberModel>()
            }
        }
        static int Triangle(int n) { return (n * (n + 1)) / 2; }
        static int Square(int n) { return n * n; }
        static int Pentagonal(int n) { return (n * (3 * n - 1)) / 2; }
        static int Hexagonal(int n) { return n * (2 * n - 1); }
        static int Heptagonal(int n) { return (n * (5 * n - 3)) / 2; }
        static int Octagonal(int n) { return n * (3 * n - 2); }
    }
}
||||||| .r0
=======
﻿using System;
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
>>>>>>> .r110
