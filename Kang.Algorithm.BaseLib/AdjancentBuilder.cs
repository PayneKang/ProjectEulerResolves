using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class AdjancentBuilder
    {
        public static int ProductOfAdjancementRight(int[][] matrix, int row, int column, int length)
        {
            if (column + length > matrix.Length)
                return -1;
            int result = 1;
            for (int i = 0; i < length; i++)
            {
                result = result * matrix[row][column + i];
            }
            return result;
        }
        public static int ProductOfAdjancementDown(int[][] matrix, int row, int column, int length)
        {
            if (row + length > matrix.Length)
                return -1;
            int result = 1;
            for (int i = 0; i < length; i++)
            {
                result = result * matrix[row + i][column];
            }
            return result;
        }
        public static int ProductOfAdjancementLeftDown(int[][] matrix, int row, int column, int length)
        {
            if (row + length > matrix.Length)
                return -1;
            if (column < length - 1)
                return -1;
            int result = 1;
            for (int i = 0; i < length; i++)
            {
                result = result * matrix[row + i][column - i];
            }
            return result;
        }
        public static int ProductOfAdjancementRightDown(int[][] matrix, int row, int column, int length)
        {
            if (row + length > matrix.Length)
                return -1;
            if (column + length > matrix.Length)
                return -1;
            int result = 1;
            for (int i = 0; i < length; i++)
            {
                result = result * matrix[row + i][column + i];
            }
            return result;
        }
    }
}
