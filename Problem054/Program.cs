using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem054
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = FileReader.ReadFile("p054_poker.txt");
            string[] cardPlays = str.Split('\n');
            int playerOneWin = 0;
            int playerTwoWin = 0;
            int draw = 0;
            foreach (string players in cardPlays)
            {
                string playerOne = players.Substring(0, 14);
                string playerTwo = players.Substring(15, 14);
                Hands handOne = new Hands(playerOne);
                Hands handTwo = new Hands(playerTwo);
                int compair = Hands.Compair(handOne, handTwo);
                if (compair == 0)
                    draw++;
                if (compair == 1)
                    playerOneWin++;
                if (compair == -1)
                    playerTwoWin++;
            }
            Console.WriteLine(string.Format("Result is {0}", playerOneWin));
        }
    }
}
