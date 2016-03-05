using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem081
{
    class Program
    {
        class PathNode
        {
            public long NodeValue { get; set; }
            public long NodePathSum { get; set; }
        }
        //const string FILENAME = "test.txt";
        const string FILENAME = "p081_matrix.txt";
        static void Main(string[] args)
        {
            string str = FileReader.ReadFile(FILENAME);
            string[] strArray = str.Replace("\n", "|").Split('|');
            int matrixWidth = strArray.Length;
            PathNode[][] matrix = new PathNode[matrixWidth][];
            for (int i = 0; i < strArray.Length; i++)
            {
                matrix[i] = new PathNode[matrixWidth];
                string line = strArray[i];
                string[] numStrs = line.Split(',');
                for (int j = 0; j < numStrs.Length; j++)
                {
                    string numStr = numStrs[j];
                    matrix[i][j] = new PathNode() { NodeValue = int.Parse(numStr), NodePathSum = 0 };
                }
            }
            matrix[matrixWidth - 1][matrixWidth - 1].NodePathSum = matrix[matrixWidth - 1][matrixWidth - 1].NodeValue;
            int currSub = 1;
            while (currSub < matrixWidth)
            {
                // 从下向上计算左侧
                int colIndex = matrixWidth - currSub - 1;
                int tempRowIndex = 0;
                for (int i = 0; i < currSub; i++)
                {
                    tempRowIndex = matrixWidth - i - 1;
                    // 下方
                    long tempDownSum = long.MaxValue;
                    if (i > 0)
                    {
                        tempDownSum = matrix[tempRowIndex + 1][colIndex].NodePathSum;
                    }
                    // 右侧
                    long tempRightSum = matrix[tempRowIndex][colIndex + 1].NodePathSum;
                    matrix[tempRowIndex][colIndex].NodePathSum = matrix[tempRowIndex][colIndex].NodeValue + Math.Min(tempDownSum, tempRightSum);
                }
                // 从右向左计算顶部
                int rowIndex = matrixWidth - currSub - 1;
                int tempColumnIndex = 0;
                for (int i = 0; i < currSub; i++)
                {
                    tempColumnIndex = matrixWidth - i - 1;
                    // 下方
                    long tempDownSum = matrix[rowIndex + 1][tempColumnIndex].NodePathSum;
                    // 右侧
                    long tempRightSum = long.MaxValue;
                    if (i > 0)
                    {
                        tempRightSum = matrix[rowIndex][tempColumnIndex + 1].NodePathSum;
                    }
                    matrix[rowIndex][tempColumnIndex].NodePathSum = matrix[rowIndex][tempColumnIndex].NodeValue + Math.Min(tempDownSum, tempRightSum);
                }
                // 计算左上角
                matrix[rowIndex][colIndex].NodePathSum = matrix[rowIndex][colIndex].NodeValue + Math.Min(matrix[rowIndex + 1][colIndex].NodePathSum, matrix[rowIndex][colIndex + 1].NodePathSum);
                currSub++;
            }
            Console.WriteLine("Result is {0}", matrix[0][0].NodePathSum);
        }
    }
}
