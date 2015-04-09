using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem032
{
    class Program
    {
        static int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static List<int> products = new List<int>();
        static void Main(string[] args)
        {
            List<int[]> seeds =  PermutationProvider.BuildPermutation<int>(numbers, 9);
            foreach (int[] seed in seeds)
            {
                BuildAndCheckFormula(seed);
            }
            int result = products.Distinct().Sum();
            Console.WriteLine(result);
        }
        static void BuildAndCheckFormula(int[] numbers)
        {
            for (int multiplicandLength = 1; multiplicandLength <= 9; multiplicandLength++)
            {
                for (int multiplierLength = 1; multiplierLength < 9 - multiplicandLength; multiplierLength++)
                {
                    int[] formula = new int[3];
                    int mulitplicand = 0;
                    for (int i = 0; i < multiplicandLength; i++)
                    {
                        mulitplicand += numbers[i] * (int)Math.Pow(10, multiplicandLength - i - 1);
                    }
                    int mulitplier = 0;
                    for (int i = 0; i < multiplierLength; i++)
                    {
                        mulitplier += numbers[i + multiplicandLength] * (int)Math.Pow(10, multiplierLength - i - 1);
                    }
                    int product = 0;
                    int productLength = 9 - multiplicandLength - multiplierLength;
                    for (int i = 0; i < productLength; i++)
                    {
                        product += numbers[i + multiplicandLength + multiplierLength] * (int)Math.Pow(10, productLength - i - 1);
                    }
                    formula[0] = mulitplicand;
                    formula[1] = mulitplier;
                    formula[2] = product;
                    if (mulitplicand * mulitplier == product)
                        products.Add(product);
                }
            }
        }
    }
}
