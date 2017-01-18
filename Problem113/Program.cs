using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem113
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
                    Value.Add(new DirectionDigit() { NumValue = 0, Direction = Direction.Any });
                    return;
                }
                int[] digits = NumberUtils.SplitNumber(val, 1);
                for (int i = 0; i < digits.Length; i++)
                {
                    Value.Add(new DirectionDigit() { NumValue = digits[i], Direction = Direction.Unknown });
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
                    result.Value[currDigitIndex].NumValue++;
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
        static BigInteger[] digitDowns = new BigInteger[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static BigInteger[] digitUps = new BigInteger[10] { 0, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        static BigInteger sumDown = 45;
        static BigInteger sumUp = 36;
        static BigInteger sumAny = 0;
        static BigInteger sumUnBouncy = 0;
        static int index = 2;

        static void Calculate()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                    continue;
                digitDowns[i] = 1 + digitDowns[i - 1] + digitDowns[i];
            }
            BigInteger tempDown = 0;
            for (int i = 0; i < 10; i++)
            {
                 tempDown += digitDowns[i];
            }
            BigInteger tempLastDown = digitDowns[9];
            sumDown += tempDown;
            sumUp = tempDown - tempLastDown + sumUp;
        }
        static void Main(string[] args)
        {
            for (int i = 3; i <= 100; i++)
            {
                Calculate();
                sumAny = 9 * i;
                sumUnBouncy = sumAny + sumDown + sumUp;
            }
            Console.WriteLine("Result is {0}", sumUnBouncy);
        }
    }
}
