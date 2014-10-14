using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.Models
{
    public class PathNode
    {
        public PathNode(int x, int y, bool canLeft, bool canRight, bool canUp, bool canDown, bool isStart, bool isEnd)
        {
            this.X = x;
            this.Y = y;
            this.CanLeft = canLeft;
            this.CanRight = canRight;
            this.CanUp = canUp;
            this.CanDown = canDown;
            this.CurrentDirection = Direction.None;
            this.IsStart = isStart;
            this.IsEnd = isEnd;
        }
        public Direction CurrentDirection { get; set; }
        public PathNode PreNode { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool CanLeft { get; private set; }
        public bool CanRight { get; private set; }
        public bool CanUp { get; private set; }
        public bool CanDown { get; private set; }
        public bool IsStart { get; private set; }
        public bool IsEnd { get; private set; }
    }
}
