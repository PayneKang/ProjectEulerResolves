using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem028
{
    class Program
    {
        const int SIZE = 1001;
        static void Main(string[] args)
        {
            long[][] matrix = ClockwiseMatrixBuilder.BuildClockwiseMatrix(SIZE);
            long result = 0;
            for (int i = 0; i < SIZE; i++)
            {
                result += matrix[i][i];
                result += matrix[i][SIZE - i - 1];
            }
            if (SIZE % 2 == 1)
            {
                result--;
            }
            Console.Write(result);
        }
    }
}
