using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem090
{
    class Program
    {
        static int[] seeds = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 , 9 };
        static int seedsCount = 0;
        static int[][] squraes = new int[][] { new int[] { 0, 1 }, new int[] { 0, 4 }, new int[] { 0, 6 }
            , new int[] { 1,6 } , new int[]{ 2, 5}, new int[]{3, 6}
            , new int[]{ 4, 6}, new int[]{ 6, 4}, new int[]{ 8, 1} };
        static void Main(string[] args)
        {
            seedsCount = seeds.Count();
            List<int[]> cubeAList = buildAllCube(0, 6);
            List<int[]> cubeBList = buildAllCube(0, 6);
            List<List<int[]>> cubePairs = new List<List<int[]>>();
            foreach (int[] cubeA in cubeAList)
            {
                foreach (int[] cubeB in cubeBList)
                {
                    if (!CheckBuildAllSquares(cubeA, cubeB))
                        continue;
                    cubePairs.Add(new List<int[]>() { cubeA, cubeB });
                }
            }
            Dictionary<string, object> filterCure = new Dictionary<string, object>();
            foreach (List<int[]> cubepair in cubePairs)
            {
                string key = BuildKey(cubepair[0], cubepair[1]);
                if (filterCure.ContainsKey(key))
                    continue;
                filterCure.Add(key, null);
            }
            Console.WriteLine("Result is {0}" ,filterCure.Count);
        }
        static string BuildKey(int[] cubeA, int[] cubeB)
        {
            string keyA = string.Join("", cubeA);
            string keyB = string.Join("", cubeB);
            if (string.Compare(keyA, keyB) > 0)
                return string.Format("{0}-{1}", keyA, keyB);
            return string.Format("{0}-{1}", keyB, keyA);
        }
        static bool CheckBuildAllSquares(int[] cubeA, int[] cubeB)
        {
            foreach (int[] square in squraes)
            {
                int a = square[0];
                int b = square[1];
                int[] tempA = new int[6];
                int[] tempB = new int[6];
                cubeA.CopyTo(tempA, 0);
                cubeB.CopyTo(tempB, 0);
                for (int i = 0; i < 6; i++)
                {
                    if (tempA[i] == 9)
                        tempA[i] = 6;
                    if (tempB[i] == 9)
                        tempB[i] = 6;
                }
                if ((tempA.Contains(a) && tempB.Contains(b)) || (tempA.Contains(b) && tempB.Contains(a)))
                    continue;
                return false;
            }
            return true;
        }
        static List<int[]> buildAllCube(int currIndex,int remainCount)
        {
            List<int[]> result = new List<int[]>();
            if (remainCount == 1)
            {
                for (int i = currIndex; i <= seedsCount - remainCount; i++)
                {
                    result.Add(new int[] { seeds[i] });
                }
                return result;
            }
            for (int i = currIndex; i <= seedsCount - remainCount; i++)
            {
                int currNum = seeds[i];
                List<int[]> childCubes = buildAllCube(i + 1, remainCount - 1);
                foreach (int[] cube in childCubes)
                {
                    int[] currCube = new int[cube.Length + 1];
                    currCube[0] = currNum;
                    cube.CopyTo(currCube, 1);
                    result.Add(currCube);
                }
            }
            return result;
        }
    }
}
