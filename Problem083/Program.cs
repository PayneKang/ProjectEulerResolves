using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem083
{
    class Program
    {
        //const string FILENAME = "test.txt";
        const string FILENAME = "p081_matrix.txt";
        static int[][] distance;
        static int[][] GRID;

        static int INFINITY = int.MaxValue / 2; 
        static void Main(string[] args)
        {
            InitMatrix();
            GRID = InitMatrix();
            int height = GRID.Length;
            int width = GRID[0].Length;

            distance = new int[height][];
            for (int i = 0; i < height; i++)
            {
                distance[i] = new int[width];
                for (int j = 0; j < width; j++)
                {
                    distance[i][j] = INFINITY;
                }
            }
            distance[0][0] = GRID[0][0];
            for (int i = 0; i < height * width; i++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int temp = INFINITY;
                        temp = Math.Min(GetDistance(x - 1, y), temp);
                        temp = Math.Min(GetDistance(x + 1, y), temp);
                        temp = Math.Min(GetDistance(x, y - 1), temp);
                        temp = Math.Min(GetDistance(x, y + 1), temp);
                        distance[y][x] = Math.Min(GRID[y][x] + temp, distance[y][x]);
                    }
                }
            }
            Console.WriteLine("Result is {0}", distance[height - 1][width - 1]);
        }
        static int GetDistance(int x, int y)
        {
            if (y < 0 || y >= distance.Length || x < 0 || x >= distance.Length)
                return INFINITY;
            return distance[y][x];
        }
        static int[][] InitMatrix()
        {
            string str = FileReader.ReadFile(FILENAME);
            string[] strArray = str.Replace("\n", "|").Split('|');
            int matrixWidth = strArray.Length;
            int[][] distance = new int[matrixWidth][];
            for (int i = 0; i < strArray.Length; i++)
            {
                distance[i] = new int[matrixWidth];
                string line = strArray[i];
                string[] numStrs = line.Split(',');
                for (int j = 0; j < numStrs.Length; j++)
                {
                    string numStr = numStrs[j];
                    distance[i][j] = int.Parse(numStr);

                }
            }
            return distance;
        }
    }
}
