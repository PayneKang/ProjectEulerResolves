using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib.Models;
using System.Threading;

namespace Kang.Algorithm.BaseLib
{
    public class MatrixPathBuilder
    {
        public MatrixPathBuilder() { TotalCount = 0; }
        public PathNode[][] Matrix { get; private set; }
        public PathNode CurrentNode { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int TotalCount { get; private set; }
        public void CountPath(int x,int y)
        {
            // 如果到了终点，则给总数 + 1
            if (x == Width && y == Height)
            {
                TotalCount++;
                return;
            }
            // 右侧
            if (x < Width)
                CountPath(x + 1, y);        
            // 下方
            if (y < Height)
                CountPath(x, y + 1);

        }
        public void BuildNodeMartix(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public void Back()
        {
            PathNode preNode = this.CurrentNode.PreNode;
            this.CurrentNode.CurrentDirection = Direction.None;
            this.CurrentNode.PreNode = null;
            this.CurrentNode = preNode;

        }
        public bool MoveLeft()
        {
            if (this.CurrentNode.CanLeft)
            {
                int x = this.CurrentNode.X;
                int y = this.CurrentNode.Y;
                this.CurrentNode = Matrix[this.CurrentNode.X][this.CurrentNode.Y - 1];
                this.CurrentNode.PreNode = Matrix[x][y];
                this.CurrentNode.PreNode.CurrentDirection = Direction.Left;
                return true;
            }
            return false;
        }
        public bool MoveRight()
        {
            if (this.CurrentNode.CanRight)
            {
                int x = this.CurrentNode.X;
                int y = this.CurrentNode.Y;
                this.CurrentNode = Matrix[this.CurrentNode.X][this.CurrentNode.Y + 1];
                this.CurrentNode.PreNode = Matrix[x][y];
                this.CurrentNode.PreNode.CurrentDirection = Direction.Right;
                return true;
            }
            return false;
        }
        public bool MoveUp()
        {
            if (this.CurrentNode.CanUp)
            {
                int x = this.CurrentNode.X;
                int y = this.CurrentNode.Y;
                this.CurrentNode = Matrix[this.CurrentNode.X - 1][this.CurrentNode.Y];
                this.CurrentNode.PreNode = Matrix[x][y];
                this.CurrentNode.PreNode.CurrentDirection = Direction.Up;
                return true;
            }
            return false;
        }
        public bool MoveDown()
        {
            if (this.CurrentNode.CanDown)
            {
                int x = this.CurrentNode.X;
                int y = this.CurrentNode.Y;
                this.CurrentNode = Matrix[this.CurrentNode.X + 1][this.CurrentNode.Y];
                this.CurrentNode.PreNode = Matrix[x][y];
                this.CurrentNode.PreNode.CurrentDirection = Direction.Down;
                return true;
            }
            return false;
        }
        
    }
}
