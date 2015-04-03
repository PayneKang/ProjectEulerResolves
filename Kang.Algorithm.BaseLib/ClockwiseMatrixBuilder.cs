using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    public class ClockwiseMatrixBuilder
    {
        public static long[][] BuildClockwiseMatrix(int size)
        {
            int xPos = 0, yPos = 0, currentNum = 1;
            long[][] matrix = new long[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new long[size];
            }
            int startPos = size % 2 == 0 ? size / 2 - 1 : size / 2;
            xPos = startPos;
            yPos = startPos;
            matrix[xPos][yPos] = currentNum;
            for (int i = 0; i < size; )
            {
                i++;
                if (i >= size)
                    break;
                DrawRight(1, ref currentNum, ref matrix, ref xPos, ref yPos);
                DrawDown(i, ref currentNum, ref matrix, ref xPos, ref yPos);
                DrawLeft(i, ref currentNum, ref matrix, ref xPos, ref yPos);

                i++;
                if (i >= size)
                    break;
                DrawLeft(1, ref currentNum, ref matrix, ref xPos, ref yPos);
                DrawUp(i, ref currentNum, ref matrix, ref xPos, ref yPos);
                DrawRight(i, ref currentNum, ref matrix, ref xPos, ref yPos);
            }
            return matrix;
        }
        static void DrawRight(int length, ref int currentNum, ref long[][] matrix, ref int xPos, ref int yPos)
        {
            for (int i = 0; i < length; i++)
            {
                currentNum++;
                xPos++;
                matrix[xPos][yPos] = currentNum;
            }
        }
        static void DrawDown(int length, ref int currentNum, ref long[][] matrix, ref int xPos, ref int yPos)
        {
            for (int i = 0; i < length; i++)
            {
                currentNum++;
                yPos++;
                matrix[xPos][yPos] = currentNum;
            }
        }
        static void DrawLeft(int length, ref int currentNum, ref long[][] matrix, ref int xPos, ref int yPos)
        {
            for (int i = 0; i < length; i++)
            {
                currentNum++;
                xPos--;
                matrix[xPos][yPos] = currentNum;
            }
        }
        static void DrawUp(int length, ref int currentNum, ref long[][] matrix, ref int xPos, ref int yPos)
        {
            for (int i = 0; i < length; i++)
            {
                currentNum++;
                yPos--;
                matrix[xPos][yPos] = currentNum;
            }
        }
    }
}