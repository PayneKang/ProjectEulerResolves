using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem011
{
    class Program
    {
        static void Main(string[] args)
        {
            string matrixNumbers = FileReader.ReadFile("Matrix.txt",System.Text.Encoding.GetEncoding("gb2312"));
            string[] lines = matrixNumbers.Replace("\r\n", "|").Split('|');
            int[][] matrix = new int[lines.Length][];
            for(int i = 0; i < lines.Length ; i++){
                string[] numArray = lines[i].Split(' ');
                matrix[i] = new int[numArray.Length];
                for (int m = 0; m < numArray.Length; m++)
                {
                    matrix[i][m] = int.Parse(numArray[m]);
                }
            }
            int maxVal = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int m = 0; m < 20; m++)
                {
                    int rightProduct = AdjancentBuilder.ProductOfAdjancementRight(matrix, i, m, 4);
                    if (maxVal < rightProduct)
                        maxVal = rightProduct;
                    int downProduct = AdjancentBuilder.ProductOfAdjancementDown(matrix, i, m, 4);
                    if (maxVal < downProduct)
                        maxVal = downProduct;
                    int downleftProduct = AdjancentBuilder.ProductOfAdjancementLeftDown(matrix, i, m, 4);
                    if (maxVal < downleftProduct)
                        maxVal = downleftProduct;
                    int downrightProduct = AdjancentBuilder.ProductOfAdjancementRightDown(matrix, i, m, 4);
                    if (maxVal < downrightProduct)
                        maxVal = downrightProduct;
                }
            }
            Console.WriteLine(maxVal);
            Console.Read();
            
        }
    }
}
