using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem112
{
    class Program
    {
        public enum Direction
        {
            Any,
            Up,
            Down,
            Bouncy,
            Unknown
        }
        public class DirectionDigit
        {
            public long NumValue { get; set; }
            public Direction Direction { get; set; }
            public override string ToString()
            {
                return NumValue.ToString();
            }
        }
        public class DirectionNumber
        {
            public List<DirectionDigit> Value { get; set; }
            public override string ToString()
            {
                if (Value == null)
                    return "Null";
                StringBuilder sb = new StringBuilder();
                for (int i = Value.Count - 1; i >= 0; i--)
                {
                    sb.Append(Value[i].ToString());
                }
                return sb.ToString();
            }
            private void SetDirection(int currIndex)
            {
                DirectionDigit curr = Value[currIndex];
                if (currIndex == Value.Count - 1)
                {
                    curr.Direction = Direction.Any;
                    return;
                }
                DirectionDigit pre = Value[currIndex + 1];
                if (curr.NumValue > pre.NumValue)
                {
                    if (pre.Direction == Direction.Any || pre.Direction == Direction.Up)
                    {
                        curr.Direction = Direction.Up;
                        return;
                    }
                    curr.Direction = Direction.Bouncy;
                    return;
                }
                if (curr.NumValue < pre.NumValue)
                {
                    if (pre.Direction == Direction.Any || pre.Direction == Direction.Down)
                    {
                        curr.Direction = Direction.Down;
                        return;
                    }
                    curr.Direction = Direction.Bouncy;
                    return;
                }
                if (curr.NumValue == pre.NumValue)
                {
                    curr.Direction = pre.Direction;
                    return;
                }

            }
            public DirectionNumber(int val)
            {
                Value = new List<DirectionDigit>();
                if (val == 0)
                {
                    Value.Add(new DirectionDigit() { NumValue = 0,Direction= Direction.Any });
                    return;
                }
                int[] digits = NumberUtils.SplitNumber(val, 1);
                for (int i = 0; i < digits.Length; i++)
                {
                    Value.Add(new DirectionDigit() { NumValue = digits[i],Direction= Direction.Unknown });
                }
                for (int i = Value.Count - 1; i >= 0; i--)
                {
                    SetDirection(i);
                }
            }
            public static DirectionNumber operator ++(DirectionNumber left)
            {
                DirectionNumber result = left;
                bool updigit = false;
                int currDigitIndex = 0;
                while (true)
                {
                    result.Value[currDigitIndex].NumValue ++;
                    if (result.Value[currDigitIndex].NumValue < 10)
                        break;
                    result.Value[currDigitIndex].NumValue = result.Value[currDigitIndex].NumValue % 10;
                    currDigitIndex++;
                    if (currDigitIndex >= result.Value.Count)
                    {
                        result.Value.Add(new DirectionDigit() { NumValue = 1, Direction = Direction.Any });
                        break;
                    }
                }
                for (int i = currDigitIndex; i >= 0; i--)
                {
                    result.SetDirection(i);
                }
                return result;
            }
        }
        static void Main(string[] args)
        {
            int totalCount = 99;
            DirectionNumber num = new DirectionNumber(99);
            int bCount = 0;
            float percent = 0.0f;
            while (100 * bCount < 99 * totalCount)
            {
                totalCount++;
                num++;
                if (num.Value[0].Direction == Direction.Bouncy)                
                    bCount ++;
            }

            Console.WriteLine("Result is {0}", num.ToString());

        }
        static bool isBouncy(int number)
        {

            bool inc = false;
            bool dec = false;

            int last = number % 10;
            number /= 10;

            while (number > 0)
            {
                int next = number % 10;
                number /= 10;
                if (next < last)
                    inc = true;
                else if (next > last)
                    dec = true;

                last = next;

                if (dec && inc) return true;
            }

            return dec && inc;
        }
    }
}
