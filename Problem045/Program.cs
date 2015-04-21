using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem045
{
    class Program
    {
        static void Main(string[] args)
        {
            long TriangleIndex = 1, PentagonalIndex = 1, HexagonalIndex = 1;
            long TriangleNum = 0, PentagonalNum = Pentagonal(PentagonalIndex), HexagonalNum = Hexagonal(HexagonalIndex);
            bool equals = true;
            int count = 0;
            while (true)
            {
                equals = true;
                TriangleNum = Triangle(TriangleIndex);
                while (TriangleNum > PentagonalNum)
                {
                    PentagonalIndex++;
                    PentagonalNum = Pentagonal(PentagonalIndex);
                }
                if (TriangleNum != PentagonalNum)
                {
                    TriangleIndex++;
                    continue;
                }
                while (TriangleNum > HexagonalNum)
                {
                    HexagonalIndex++;
                    HexagonalNum = Hexagonal(HexagonalIndex);
                }
                if (TriangleNum != HexagonalNum)
                {
                    TriangleIndex++;
                    continue;
                }
                Console.WriteLine(string.Format("Triangle[{0}] = {1}\r\nPentagonal[{2}]={3}\r\nHexagonal[{4}]={5}",TriangleIndex,TriangleNum,PentagonalIndex,PentagonalNum,HexagonalIndex,HexagonalNum));
                TriangleIndex++;
                count++;
                if (count == 3)
                    break;
            }
            Console.WriteLine(string.Format("Result is {0}", TriangleNum));
        }
        static long Triangle(long num)
        {
            return (num * (num + 1)) / 2;
        }
        static long Pentagonal(long num)
        {
            return (num * (3 * num - 1)) / 2;
        }
        static long Hexagonal(long num)
        {
            return num * (2 * num - 1);
        }
    }
}
