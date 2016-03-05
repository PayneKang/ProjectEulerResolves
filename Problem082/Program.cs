using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem082
{
    class Program
    {
        class PathNode
        {
            public int NodeValue { get; set; }
            public int NodePathSum { get; set; }
        }
        //const string FILENAME = "test.txt";
        const string FILENAME = "p082_matrix.txt";
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
            for (int col = 0; col < matrixWidth; col++)
            {
                matrix[matrixWidth - 1 - col][matrixWidth - 1].NodePathSum = matrix[matrixWidth - 1 - col][matrixWidth - 1].NodeValue;
            }
            int currSub = 1;
            while (currSub < matrixWidth)
            {
                int leftIndex = matrixWidth - 1 - currSub;
                // 遍历左侧所有节点，计算最短路径
                for (int tempRowIndex = 0; tempRowIndex < matrixWidth; tempRowIndex++)
                {
                    // 计算向上的最短路径
                    int upMin = int.MaxValue;
                    if (tempRowIndex > 0)
                    {
                        List<int> upValues = new List<int>();
                        int tempUp = 0;
                        for (int startRow = tempRowIndex - 1; startRow >= 0; startRow--)
                        {
                            tempUp += matrix[startRow][leftIndex].NodeValue;
                            upValues.Add(tempUp + matrix[startRow][leftIndex+1].NodePathSum);
                        }
                        upMin = upValues.Min();
                    }
                    // 计算向下的最短路径
                    int downMin = int.MaxValue;
                    if (tempRowIndex < matrixWidth - 1)
                    {
                        List<int> downValus = new List<int>();
                        int tempDown = 0;
                        for (int startRow = tempRowIndex + 1; startRow < matrixWidth; startRow++)
                        {
                            tempDown += matrix[startRow][leftIndex].NodeValue;
                            downValus.Add(tempDown + matrix[startRow][leftIndex + 1].NodePathSum);
                        }
                        downMin = downValus.Min();
                    }
                    // 计算向右的路径
                    int rightPath = matrix[tempRowIndex][leftIndex + 1].NodePathSum;
                    // 取最短路径
                    int shortPath = new int[] { upMin, downMin, rightPath }.Min();
                    // 设定当前节点到右侧的最短路径
                    matrix[tempRowIndex][leftIndex].NodePathSum = matrix[tempRowIndex][leftIndex].NodeValue + shortPath;
                }
                currSub++;
            }
            int result = int.MaxValue;
            foreach (PathNode[] rows in matrix)
            {
                if (rows[0].NodePathSum < result)
                    result = rows[0].NodePathSum;
            }
            Console.WriteLine("Result is {0}", result);
        }
    }
}
