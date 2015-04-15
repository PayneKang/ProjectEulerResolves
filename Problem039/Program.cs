using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem039
{
    class Program
    {
        static List<int[]> BuildRightAngleTriangles(int perimeter)
        {
            int maxSide = (int)(perimeter / (2 + Math.Sqrt(2)));
            List<int[]> result = new List<int[]>();
            for (int sideA = 1; sideA <= maxSide; sideA++)
            {
                int sideB = ((perimeter - sideA) * (perimeter - sideA) - sideA * sideA) / (2 * (perimeter - sideA));
                int sideC = perimeter - sideA - sideB;
                if (sideA * sideA + sideB * sideB != sideC * sideC)
                    continue;
                int[] temp = new int[] { sideA, sideB, sideC };
                result.Add(temp);
            }
            return result;
        }
        static void Main(string[] args)
        {
            int maxP = 0;
            List<int[]> maxResult = new List<int[]>();
            for (int i = 1; i <= 1000; i++)
            {
                List<int[]> result = BuildRightAngleTriangles(i);
                if (maxResult.Count >= result.Count)
                    continue;
                maxResult = result;
                maxP = i;
            }
            Console.WriteLine(string.Format("Result is {0}",maxP));
        }
    }
}
