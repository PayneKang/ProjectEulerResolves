using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem107
{
    class Program
    {
        class Node
        {
            public int Index { get; set; }
            public List<Node> Children { get; set; }
            public int Weight { get; set; }
        }
        const string treeStr = @"-,16,12,21,-,-,-
16,-,-,17,20,-,-
12,-,-,28,-,31,-
21,17,28,-,18,19,23
-,20,-,18,-,-,11
-,-,31,19,-,-,27
-,-,-,23,11,27,-";
        static int[][] matrix;
        static void Main(string[] args)
        {
            string[] lines = treeStr.Replace("\r\n","|").Split('|');
            matrix = new int[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] items = lines[i].Split(',');
                matrix[i] = new int[items.Length];
                for (int j = 0; j < items.Length; j++)
                {
                    if (items[j].Equals("-"))
                    {
                        matrix[i][j] = int.MaxValue;
                        continue;
                    }
                    matrix[i][j] = int.Parse(items[j]);
                }
            }
            Node rootNode = new Node()
            {
                Children = new List<Node>(),
                Index = 0,
                Weight = 0
            };
            rootNode.Children = BuildChildren(rootNode, new List<int>() { 0 });
        }
        static List<Node> BuildChildren(Node currNode, List<int> existIndex)
        {
            int[] childrenRow = matrix[currNode.Index];
            List<Node> result = new List<Node>();
            for (int i = 0; i <  childrenRow.Length; i++)
            {
                int num = childrenRow[i];
                if (num.Equals(int.MaxValue))
                    continue;
                if (existIndex.Contains(i))
                    continue;
                Node child = new Node()
                {
                    Index = i,
                    Weight = num
                };
                existIndex.Add(i);
                child.Children = BuildChildren(child, existIndex);
                existIndex.Remove(i);
                result.Add(child);
            }
            return result;
        }
    }
}
