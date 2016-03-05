using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem083
{
    class Program
    {
        class PathNode
        {
            public long NodeValue { get; set; }
            public bool IsInPath { get; set; }
            public bool IsStart { get; set; }
            public bool IsEnd { get; set; }
            public long CurrentPathSum { get; set; }
            public int Direction { get; set; }
            public PathNode LeftNode { get; set; }
            public PathNode RightNode { get; set; }
            public PathNode DownNode { get; set; }
            public PathNode UpNode { get; set; }
            public PathNode PreNode { get; set; }
            public PathNode NextNode { get; set; }
            public PathNode GoRight()
            {
                this.Direction++;
                if (this.RightNode == null)
                    return null;
                if (this.RightNode.IsInPath)
                    return null;
                if (this.RightNode.NodeValue + this.CurrentPathSum > minResult)
                    return null;
                pathLength++;
                this.NextNode = this.RightNode;
                this.NextNode.IsInPath = true;
                this.NextNode.PreNode = this;
                this.NextNode.CurrentPathSum = this.NextNode.NodeValue + this.CurrentPathSum;
                return this.RightNode;
            }
            public PathNode GoDown()
            {
                this.Direction++;
                if (this.DownNode == null)
                    return null;
                if (this.DownNode.IsInPath)
                    return null;
                if (this.DownNode.NodeValue + this.CurrentPathSum > minResult)
                    return null;
                pathLength++;
                this.NextNode = this.DownNode;
                this.DownNode.IsInPath = true;
                this.DownNode.PreNode = this;
                this.NextNode.CurrentPathSum = this.DownNode.NodeValue + this.CurrentPathSum;
                return this.DownNode;
            }
            public PathNode GoLeft()
            {
                this.Direction++;
                if (this.LeftNode == null)
                    return null;
                if (this.LeftNode.IsInPath)
                    return null;
                if (this.LeftNode.NodeValue + this.CurrentPathSum > minResult)
                    return null;
                pathLength++;
                this.NextNode = this.LeftNode;
                this.LeftNode.IsInPath = true;
                this.LeftNode.PreNode = this;
                this.NextNode.CurrentPathSum = this.LeftNode.NodeValue + this.CurrentPathSum;
                return this.LeftNode;
            }
            public PathNode GoUp()
            {
                this.Direction++;
                if (this.UpNode == null)
                    return null;
                if (this.UpNode.IsInPath)
                    return null;
                if (this.UpNode.NodeValue + this.CurrentPathSum > minResult)
                    return null;
                pathLength++;
                this.NextNode = this.UpNode;
                this.UpNode.IsInPath = true;
                this.UpNode.PreNode = this;
                this.NextNode.CurrentPathSum = this.UpNode.NodeValue + this.CurrentPathSum;
                return this.UpNode;
            }
            public PathNode GoBack()
            {
                if (this.PreNode == null)
                    return null;
                pathLength--;
                this.CurrentPathSum = 0;
                this.NextNode = null;
                this.IsInPath = false;
                PathNode prenode = this.PreNode;
                this.PreNode = null;
                this.Direction = 0;
                return prenode;
            }
        }
        static int pathLength = 1;
        static PathNode[][] matrix;
        static int matrixWidth;        
        static long minResult = int.MaxValue;
        //const string FILENAME = "test.txt";
        const string FILENAME = "p081_matrix.txt";
        static void Main(string[] args)
        {
            InitMatrix();
            matrix[0][0].IsInPath = true;
            FindPath(matrix[0][0]);
        }
        static bool CheckEnd(PathNode currNode)
        {
            if (!currNode.IsEnd)
                return false;
            StringBuilder path = new StringBuilder("Start");
            PathNode node = matrix[0][0];
            while (true)
            {
                path.Append(string.Format(" -> {0}", node.NodeValue));
                if (node.IsEnd)
                    break;
                node = node.NextNode;
            }
            if (currNode.CurrentPathSum < minResult)
            {
                minResult = currNode.CurrentPathSum;
            }
            Console.WriteLine(string.Format("{0}\r\n  path sum = {1}, current min = {2}, path length = {3}", path.ToString(), minResult, currNode.CurrentPathSum,pathLength));
            Console.WriteLine("********************************");
            return true;
        }
        static void FindPath(PathNode currNode)
        {
            while (true)
            {
                if (CheckEnd(currNode))
                {
                    currNode = currNode.GoBack();
                }
                if (currNode.Direction == 0)
                {
                    PathNode temp = currNode.GoRight();
                    if (temp != null)
                    {
                        currNode = temp;
                        continue;
                    }
                }
                if (currNode.Direction == 1)
                {
                    PathNode temp = currNode.GoDown();
                    if (temp != null)
                    {
                        currNode = temp;
                        continue;
                    }
                }
                if (currNode.Direction == 2)
                {
                    PathNode temp = currNode.GoLeft();
                    if (temp != null)
                    {
                        currNode = temp;
                        continue;
                    }
                }
                if (currNode.Direction == 3)
                {
                    PathNode temp = currNode.GoUp();
                    if (temp != null)
                    {
                        currNode = temp;
                        continue;
                    }
                }
                if (currNode.Direction == 4 && currNode.IsStart)
                {
                    return;
                }
                currNode = currNode.GoBack();
            }
        }
        static void InitMatrix()
        {
            string str = FileReader.ReadFile(FILENAME);
            string[] strArray = str.Replace("\n", "|").Split('|');
            matrixWidth = strArray.Length;
            matrix = new PathNode[matrixWidth][];
            for (int i = 0; i < strArray.Length; i++)
            {
                matrix[i] = new PathNode[matrixWidth];
                string line = strArray[i];
                string[] numStrs = line.Split(',');
                for (int j = 0; j < numStrs.Length; j++)
                {
                    string numStr = numStrs[j];
                    matrix[i][j] = new PathNode() { NodeValue = int.Parse(numStr), CurrentPathSum = 0 };

                }
            }

            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    if (i == 0)
                    {
                        matrix[i][j].UpNode = null;
                    }
                    else
                    {
                        matrix[i][j].UpNode = matrix[i - 1][j];
                    }
                    if (j == 0)
                    {
                        matrix[i][j].LeftNode = null;
                    }
                    else
                    {
                        matrix[i][j].LeftNode = matrix[i][j - 1];
                    }
                    if (i == matrixWidth - 1)
                    {
                        matrix[i][j].DownNode = null;
                    }
                    else
                    {
                        matrix[i][j].DownNode = matrix[i + 1][j];
                    }
                    if (j == matrixWidth - 1)
                    {
                        matrix[i][j].RightNode = null;
                    }
                    else
                    {
                        matrix[i][j].RightNode = matrix[i][j + 1];
                    }
                }
            }
            matrix[0][0].IsStart = true;
            matrix[0][0].CurrentPathSum = matrix[0][0].NodeValue;
            matrix[matrixWidth - 1][matrixWidth - 1].IsEnd = true;
        }
    }
}
