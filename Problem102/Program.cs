using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem102
{
    class Program
    {
        public class Triangle
        {
            private Triangle() { }
            public Triangle(Point a, Point b, Point c)
            {
                Edges = new Segment[3];
                Edges[0] = new Segment() { Start = a, End = b };
                Edges[0].CalculateAB();
                Edges[1] = new Segment() { Start = b, End = c };
                Edges[1].CalculateAB();
                Edges[2] = new Segment() { Start = c, End = a };
                Edges[2].CalculateAB();
            }
            public Segment[] Edges { get; set; }
            public bool IsPointInTriangle(Point p)
            {
                List<Point> pl = new List<Point>();
                List<Point> left = new List<Point>();
                List<Point> right = new List<Point>();
                foreach (Segment edge in Edges)
                {
                    Point tp = edge.FindHorizontalCrossPoint(p);
                    if (tp == null)
                        continue;
                    if(tp.Equals(p))
                        return true;
                    if (tp.X < p.X)
                        left.Add(tp);
                    if (tp.X > p.X)
                        right.Add(tp);
                    pl.Add(tp);
                }
                if (pl.Count == 0)
                    return false;
                if (left.Count == 0 || right.Count == 0)
                    return false;
                return true;

            }
        }
        public class Segment {
            public Point Start { get; set; }
            public Point End { get; set; }
            public float A { get; set; }
            public float B { get; set; }
            public void CalculateAB()
            {
                A = (Start.Y - End.Y) / (Start.X - End.X);
                B = (Start.Y * End.X - End.Y * Start.X) / (End.X - Start.X);
            }
            /// <summary>
            /// 给定纵坐标，返回此纵坐标与此线段的交点，如果没有返回null
            /// </summary>
            /// <param name="y"></param>
            /// <returns></returns>
            public Point FindHorizontalCrossPoint(Point p)
            {
                float x = 0;
                if (A == 0f)
                {
                    if (p.Y != B)
                        return null;
                    x = p.X;
                }
                else
                {
                    x = (p.Y - B) / A;
                }
                
                if (x > Start.X && x > End.X)
                    return null;
                if (x < Start.X && x < End.X)
                    return null;
                return new Point() { X = x, Y = p.Y };
            }
        }
        public class Point {
            public float X { get; set; }
            public float Y { get; set; }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (this.X != ((Point)obj).X)
                    return false;
                if (this.Y != ((Point)obj).Y)
                    return false;
                return true;
            }
        }
        static void Main(string[] args)
        {
            Point checkpoint = new Point() { X = 0, Y = 0 };
            string str = FileReader.ReadFile("p102_triangles.txt");
            string[] strArray = str.Split('\n');
            int n = 0;
            int count = 0;
            foreach (string line in strArray)
            {
                string[] items = line.Split(',');
                float[] nums = new float[items.Length];
                for (int i = 0; i < items.Length; i++)
                {
                    nums[i] = float.Parse(items[i]);
                }
                Point a = new Point() { X = nums[0], Y = nums[1] };                
                Point b = new Point() { X = nums[2], Y = nums[3] };
                Point c = new Point() { X = nums[4], Y = nums[5] };
                Triangle tran = new Triangle(a, b, c);
                if (tran.IsPointInTriangle(checkpoint))
                    count++;
                n++;
            }
            Console.WriteLine("Result is {0}", count);
        }
    }
}
