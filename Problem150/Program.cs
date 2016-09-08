using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem150
{
    class Program
    {
        public class Node
        {
            public Node(BigInteger nodeValue)
            {
                this.NodeValue = nodeValue;
                this.CurrentDepth = 1;
                this.CurrentSum = nodeValue;
                this.LeftSum = nodeValue;
            }
            public BigInteger NodeValue { get; set; }
            public int CurrentDepth { get; set; }
            public BigInteger CurrentSum { get; set; }
            public BigInteger LeftSum { get; set; }
        }
        static void Main(string[] args)
        {
            RunCalculate();
        }

        static void RunCalculate()
        {
            List<List<Node>> triangular = new List<List<Node>>();
            InitTriangular(ref triangular);
            //InitTestData(ref triangular);
            Result minsum = new Result(){SumValue = long.MaxValue};
            for (int i = 2; i <= 6; i++)
            {
                Result tmp = CalculateSumAndGetMinSum(i, ref triangular);
                if (minsum.SumValue > tmp.SumValue)
                    minsum = tmp;
            }
        }


        static void InitTestData(ref List<List<Node>> triangular)
        {
            triangular = new List<List<Node>>()
            {
                new List<Node>(){new Node(15)},
                new List<Node>(){new Node(-14),new Node(-7)},
                new List<Node>(){new Node(20),new Node(-13),new Node(-5)},
                new List<Node>(){new Node(-3),new Node(8),new Node(23),new Node(-26)},
                new List<Node>(){new Node(1),new Node(-4),new Node(-5),new Node(-18),new Node(5)},   
                new List<Node>(){new Node(-16),new Node(31),new Node(2),new Node(9),new Node(28),new Node(3)}
            };
        }
        static void InitTriangular(ref List<List<Node>> triangular)
        {
            long t = 0;
            List<Node> nodes = new List<Node>();
            long mod = (long)Math.Pow(2, 20);
            long submod = (long)Math.Pow(2, 19);
            for (int k = 1; k <= 500500; k++)
            {
                t = (615949*t + 797807)%mod;
                nodes.Add(new Node(t - submod));
            }
            int ni = 0;
            for (int i = 0; i < 1000; i++)
            {
                triangular.Add(new List<Node>());
                for (int j = 0; j <= i; j++)
                {
                    triangular[i].Add(nodes[ni]);
                    ni++;
                }
            }

        }

        public class Result
        {
            public BigInteger SumValue { get; set; }
            public int startRow { get; set; }
            public int startColumn { get; set; }
            public BigInteger startNodeValue { get; set; }
            public int depth { get; set; }

        }
        static Result CalculateSumAndGetMinSum(int depth, ref List<List<Node>> triangluar)
        {
            Result minSum = new Result() { SumValue = long.MaxValue, startColumn = 0, startNodeValue = 0, startRow =  0};
            int endBottom = triangluar.Count - depth;
            for (int row = 0; row <= endBottom; row++)
            {
                for (int column = 0; column <= row; column++)
                {
                    Node currNode = triangluar[row][column];
                    if(currNode.CurrentDepth != depth - 1)
                        throw new ApplicationException("没有完成前置计算");
                    currNode.CurrentDepth = depth;
                    currNode.CurrentSum = currNode.NodeValue + triangluar[row + 1][column].LeftSum +
                                          triangluar[row + 1][column + 1].CurrentSum;
                    currNode.LeftSum = currNode.NodeValue + triangluar[row + 1][column].LeftSum;
                    if (minSum.SumValue > currNode.CurrentSum)
                    {
                        minSum.SumValue = currNode.CurrentSum;
                        minSum.startColumn = column;
                        minSum.startRow = row;
                        minSum.startNodeValue = currNode.NodeValue;
                        minSum.depth = depth;
                    }
                }
            }
            return minSum;
        }
    }
}
