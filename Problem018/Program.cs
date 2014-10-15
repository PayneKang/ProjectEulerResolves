using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem018
{
    public class Node{
        public long MaximumPath{get;set;}
        public long Value{get;set;}
    }
    public class TriangleMatrix
    {
        public int Height { get; set; }
        public Node[][] Triangle{get;set;}
        public void BuildTriangleMatrix(string str)
        {
            string[] lines = str.Replace("\r\n", "|").Split('|');
            this.Height = lines.Length;
            this.Triangle = new Node[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] nums = lines[i].Split(' ');
                this.Triangle[i] = new Node[nums.Length];
                for (int j = 0; j < nums.Length; j++)
                {
                    this.Triangle[i][j] = new Node()
                    {
                        MaximumPath = 0,
                        Value = int.Parse(nums[j])
                    };
                }
            }
        }
    }
    class Program
    {
        static TriangleMatrix tm;
        static long GetMaximumPath(int row, int column)
        {
            if(row == tm.Height - 1){
                tm.Triangle[row][column].MaximumPath = tm.Triangle[row][column].Value;
                return tm.Triangle[row][column].MaximumPath;
            }
            long left = tm.Triangle[row+1][column].MaximumPath;
            long right = tm.Triangle[row + 1][column + 1].MaximumPath;
            tm.Triangle[row][column].MaximumPath = tm.Triangle[row][column].Value + (left > right ? left : right);
            return tm.Triangle[row][column].MaximumPath;
        }
        static void Main(string[] args)
        {
            string triangleStr =
@"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
//            string triangleStr =
//@"3
//7 4
//2 4 6
//8 5 9 3";
            tm = new TriangleMatrix();
            tm.BuildTriangleMatrix(triangleStr);
            for (int i = tm.Height - 1; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    GetMaximumPath(i, j);
                }
            }
            Console.WriteLine(tm.Triangle[0][0].MaximumPath);
            Debug.WriteLine(tm.Triangle[0][0].MaximumPath);
            Console.Read();
        }
    }
}
