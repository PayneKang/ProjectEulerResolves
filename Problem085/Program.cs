using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem085
{
    class Program
    {

        const long Target = 2000000;
        static void Main(string[] args)
        {
            long maxWidth = GetMaxWidth();
            long minDelta = Target;
            long minArea = maxWidth;
            for (long height = 1; height <= maxWidth; height++)
            {

                for (long width = 1; width <= maxWidth; width++)
                {
                    long totalCount = CountTotalRectCount(width, height);
                    long delta = Math.Abs(Target - totalCount);
                    if (minDelta > delta)
                    {
                        minDelta = delta;
                        minArea = width * height;
                    }
                    if (totalCount > Target)
                        break;
                }
            }
            Console.WriteLine("Result is {0}", minArea);
        }
        static int GetMaxWidth()
        {
            int tmp = 0;
            for (int i = 1; ; i++)
            {
                tmp += i;
                if (tmp >= Target)
                    return i;
            }
            return 0;
        }
        static long CountTotalRectCount(long totalWidth, long totalHeight)
        {
            long totalCount = 0;
            for (int rectWidth = 1; rectWidth <= totalWidth; rectWidth++)
            {
                for (int rectHeight = 1; rectHeight <= totalHeight; rectHeight++)
                {
                    totalCount += CountRectCount(totalWidth, totalHeight, rectWidth, rectHeight);
                }
            }
            return totalCount;
        }

        static long CountRectCount(long totalWidth, long totalHeight, long rectWidth, long rectHeight)
        {
            int startRow = 0;
            int startColumn = 0;
            long endRow = totalHeight - rectHeight;
            long endColumn = totalWidth - rectWidth;
            return (endRow - startRow + 1) * (endColumn - startColumn + 1);
        }
    }
}
