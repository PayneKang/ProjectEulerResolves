using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem067
{
    class Program
    {
        class TreeNode {
            public int Val { get; set; }
            public int MaxPathToLeaf { get; set; }
        }
        static void Main(string[] args)
        {
            int.Parse("3 ");
            string str = FileReader.ReadFile("triangle.txt",Encoding.UTF8).Replace("\r\n","|");
            string[] lines = str.Split('|');
            List<List<TreeNode>> tree = new List<List<TreeNode>>();
            foreach(string line in lines){
                List<TreeNode> tl = new List<TreeNode>();
                string[] items = line.Split(' ');
                foreach (string item in items)
                {
                    tl.Add(new TreeNode() { Val = int.Parse(item), MaxPathToLeaf = 0 });
                }
                tree.Add(tl);
            }
            CalculateMaxPath(tree);
            Console.WriteLine("result is {0}", tree[0][0].MaxPathToLeaf);
        }
        static void CalculateMaxPath(List<List<TreeNode>> tree)
        {
            for (int i = tree.Count - 1; i >= 0; i--)
            {
                if (i == tree.Count - 1)
                {
                    for (int j = 0; j < tree[i].Count; j++)
                    {
                        tree[i][j].MaxPathToLeaf = tree[i][j].Val;
                    }
                    continue;
                }
                for (int j = 0; j < tree[i].Count; j++)
                {
                    int left = tree[i + 1][j].MaxPathToLeaf;
                    int right = tree[i + 1][j + 1].MaxPathToLeaf;
                    tree[i][j].MaxPathToLeaf = tree[i][j].Val + (left > right ? left : right);
                }
            }
        }
    }
}
