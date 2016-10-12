using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem107
{
    class Program
    {
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
            string[] lines = File.ReadAllLines("p107_network.txt");
            //string[] lines = treeStr.Replace("\r\n","|").Split('|');
            int N = lines[0].Split(',').Length;
            DisjointSet vertices = new DisjointSet(N);
            List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
            int initialWeight = 0;
            for (int i = 0; i < N; i++)
            {
                string[] edge = lines[i].Split(',');
                for (int j = 0; j < i; j++)
                {
                    if (edge[j] == "-")
                        continue;
                    int weight = int.Parse(edge[j]);
                    edges.Add(new Tuple<int, int, int>(weight, i, j));
                    initialWeight += weight;
                }
            }
            edges.Sort();
            int k = 0;
            while (!vertices.IsSpanning())
            {
                if (vertices.Find(edges[k].Item2) != vertices.Find(edges[k].Item3))
                {
                    vertices.Union(edges[k].Item2, edges[k].Item3);
                    initialWeight -= edges[k].Item1;
                }
                k++;
            }
            Console.WriteLine("Result is {0}", initialWeight);
        }
    }
}
