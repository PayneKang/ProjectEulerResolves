using System;
using System.Collections.Generic;
using System.Linq;
﻿using System.Security.Cryptography.X509Certificates;
﻿using System.Text;

namespace Problem061
{
    public class NumberModel{
        public int NumberValue { get; set; }
        public Dictionary<string,List<NumberModel>> NextNumber { get; set; }
    }    
    class Program
    {
        public static string[] totalKeys = new string[] {"Triangle","Square","Pentagonal"};
        static List<NumberModel> BuildFormulaNumbers(Func<int, NumberModel> func)
        {
            List<NumberModel> result = new List<NumberModel>();
            // Triangle
            NumberModel rlt = new NumberModel() { NumberValue = 0, NextNumber = new Dictionary<string, List<NumberModel>>() };
            int i = 1;
            while (rlt.NumberValue < 10000)
            {
                rlt = func(i);
                i++;
                if (rlt.NumberValue < 1000)
                    continue;
                if (rlt.NumberValue >= 10000)
                    break;
                if (result.Count(x=>x.NumberValue.Equals(rlt.NumberValue)) == 0)
                    result.Add(rlt);
            }
            return result;
        }
        static Dictionary<string, List<NumberModel>> BuildNumbers()
        {
            Dictionary<string, List<NumberModel>> result = new Dictionary<string, List<NumberModel>>();
            result.Add("Triangle",BuildFormulaNumbers(Triangle));
            result.Add("Square",BuildFormulaNumbers(Square));
            result.Add("Pentagonal",BuildFormulaNumbers(Pentagonal));
            result.Add("Hexagonal", BuildFormulaNumbers(Hexagonal));
            result.Add("Heptagonal",BuildFormulaNumbers(Heptagonal));
            result.Add("Octagonal",BuildFormulaNumbers(Octagonal));
            
            return result;
        }

        static Dictionary<string, NumberModel> resultQueue = new Dictionary<string, NumberModel>();
        private const int TARGET_LENGTH = 6;
        static Dictionary<string, List<NumberModel>> numbers = BuildNumbers();
        static void Main(string[] args)
        {
            SetNextNumber();
            foreach (var number in numbers["Triangle"])
            {
                if (number.NumberValue == 8128)
                {
                    
                }
                foreach (var key in totalKeys)
                {
                    if (resultQueue.ContainsKey(key))
                        resultQueue.Remove(key);
                    
                }
                resultQueue.Add("Triangle", number);
                CheckNextNumber();
            }
        }

        private static bool foundResult = false;
        static void CheckNextNumber()
        {
            if (foundResult)
                return;
            NumberModel currNum = resultQueue.Values.Last();
            string[] nextNumKeys = currNum.NextNumber.Keys.ToArray();
            foreach (string currKey in nextNumKeys)
            {
                if (resultQueue.ContainsKey(currKey))
                    continue;
                if (currNum.NextNumber[currKey] == null)
                    continue;
                if (currNum.NextNumber[currKey].Count == 0)
                    continue;
                for (int i = 0; i < currNum.NextNumber[currKey].Count; i++)
                {
                    if (currKey.Equals("Square") && currNum.NextNumber[currKey][i].NumberValue == 2882)
                    {

                    }
                    if (currKey.Equals("Pentagonal") && currNum.NextNumber[currKey][i].NumberValue == 8281)
                    {

                    }
                    NumberModel nextNumber = currNum.NextNumber[currKey][i];
                    if (!CheckNext(currNum, nextNumber))
                        continue;
                    resultQueue.Add(currKey,nextNumber);
                    if (resultQueue.Count != TARGET_LENGTH)
                    {
                        CheckNextNumber();
                        resultQueue.Remove(currKey);
                        continue;
                    }

                    if (!CheckNext(nextNumber, resultQueue["Triangle"]))
                    {
                        CheckNextNumber();
                        resultQueue.Remove(currKey);
                        continue;
                    }

                    foundResult = true;
                    int result = 0;
                    foreach (var n in resultQueue.Values)
                    {
                        result += n.NumberValue;
                    }
                    Console.WriteLine("result is {0}", result);
                }
            }

        }

        static void SetNextNumber()
        {
            string[] keys = numbers.Keys.ToArray();
            foreach (string key in keys)
            {
                foreach (NumberModel currNum in numbers[key])
                {
                    foreach (string subKey in keys)
                    {
                        if (key.Equals(subKey))
                            continue;
                        foreach (NumberModel nextNum in numbers[subKey])
                        {
                            if (!CheckNext(currNum, nextNum))
                                continue;
                            if (!currNum.NextNumber.ContainsKey(subKey))
                                currNum.NextNumber.Add(subKey,new List<NumberModel>());
                            currNum.NextNumber[subKey].Add(nextNum);
                        }
                    }
                    
                }
            }
        }

        static bool CheckNext(NumberModel firstNum, NumberModel secondNumber)
        {
            if ((firstNum.NumberValue%100).Equals(secondNumber.NumberValue/100))
                return true;
            return false;
        }
        static NumberModel Triangle(int n) { return new NumberModel() { NumberValue = (n * (n + 1)) / 2, NextNumber = new Dictionary<string, List<NumberModel>>() }; }
        static NumberModel Square(int n) { return new NumberModel() { NumberValue = n * n, NextNumber = new Dictionary<string, List<NumberModel>>() }; }
        static NumberModel Pentagonal(int n) { return new NumberModel() { NumberValue = (n * (3 * n - 1)) / 2, NextNumber = new Dictionary<string, List<NumberModel>>() }; }
        static NumberModel Hexagonal(int n) { return new NumberModel() { NumberValue = n * (2 * n - 1), NextNumber = new Dictionary<string, List<NumberModel>>() }; }
        static NumberModel Heptagonal(int n) { return new NumberModel() { NumberValue = (n * (5 * n - 3)) / 2, NextNumber = new Dictionary<string, List<NumberModel>>() }; }
        static NumberModel Octagonal(int n) { return new NumberModel() { NumberValue = n * (3 * n - 2), NextNumber = new Dictionary<string, List<NumberModel>>() }; }
    }
}

/*
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
}*/