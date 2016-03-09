using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kang.Algorithm.BaseLib;

namespace Problem096
{
    class Program
    {
        class SudokuItem
        {
            public int Val { get; set; }
            public int RowIndex { get; set; }
            public int ColumnIndex { get; set; }
            public bool IsConfirmed { get; set; }
            private List<int> PossibleVals;
            public List<int> GetPossibleVals()
            {
                return this.PossibleVals;
            }
            public void AddPossibleVal(int val)
            {
                if (PossibleVals == null)
                    PossibleVals = new List<int>();
                if (PossibleVals.Contains(val))
                    return;
                PossibleVals.Add(val);
            }
            public void RemoviePossibleVal(int val)
            {
                if (IsConfirmed)
                {
                    throw new Exception("Calculate error");
                }
                PossibleVals.Remove(val);
                if (PossibleVals.Count == 1)
                {
                    this.Val = PossibleVals[0];
                    IsConfirmed = true;
                }
            }
        }
        class Position {
            public int Row { get; set; }
            public int Col { get; set; }
        }
        class SudokuPuzzle
        {
            public SudokuItem[][] Item { get; set; }
            public bool IsSolved
            {
                get
                {
                    for (int i = 0; i < Item.Length; i++)
                    {
                        for (int j = 0; j < Item[i].Length; j++)
                        {
                            if (!Item[i][j].IsConfirmed)
                                return false;
                        }
                    }
                    return true;
                }
            }
            public void PrintPuzzle()
            {
                Console.WriteLine("**********");
                for (int i = 0; i < Item.Length; i++)
                {
                    for (int j = 0; j < Item[i].Length; j++)
                    {
                        Console.Write(Item[i][j].Val);
                    }
                    Console.WriteLine();
                }
            }
        }
        static SudokuPuzzle SolvePuzzle(SudokuPuzzle puzzle, int startRow, int startColumn)
        {
            // 开始解谜题
            while (true)
            {

                if (puzzle.IsSolved)
                    break;
                int j = startColumn;
                for (int i = startRow; i < 9; i++)
                {
                    for (; j < 9; j++)
                    {
                        if (puzzle.Item[i][j].IsConfirmed)
                            continue;
                        List<int> possibleVals = puzzle.Item[i][j].GetPossibleVals();
                        for (int k = 0; k < possibleVals.Count; k++)
                        {
                            puzzle.Item[i][j].IsConfirmed = true;
                            puzzle.Item[i][j].Val = possibleVals[k];
                            puzzle.PrintPuzzle();
                            if (!CheckPuzzle(puzzle))
                            {
                                puzzle.Item[i][j].IsConfirmed = false;
                                puzzle.Item[i][j].Val = 0;
                                puzzle.PrintPuzzle();
                                if (k == possibleVals.Count - 1)
                                    return puzzle;
                                continue;
                            }
                            int nextRow = startRow;
                            int nextColumn = startColumn + 1;
                            if (nextColumn >= 9)
                            {
                                nextRow = nextRow + 1;
                                nextColumn = 0;
                            }
                            if (nextRow < 9)
                            {
                                puzzle = SolvePuzzle(puzzle, nextRow, nextColumn);
                            }
                        }
                    }
                    j = 0;
                }
            }
            return puzzle;
        }
        static void Main(string[] args)
        {
            List<SudokuPuzzle> puzzles = LoadPuzzles();
            for (int n = 0; n < puzzles.Count; n++)
            {
                SudokuPuzzle puzzle = puzzles[n];
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (!puzzles[n].Item[i][j].IsConfirmed)
                            continue;
                        puzzle = ClearPossiblesForACell(i, j, puzzle);
                    }
                }
            }
        }
        static SudokuPuzzle ClearPossiblesForACell(int i, int j, SudokuPuzzle puzzle)
        {
            // 读取一个值，如果此值为0，则继续下一个
            int currVal = puzzle.Item[i][j].Val;
            if (currVal == 0)
                return puzzle;
            // 清除根据此值可以排除的值
            // 清除同行的值
            int row = i;
            int col = 0;
            for (col = 0; col < 9; col++)
            {
                if (col == j)
                    continue;

                SudokuItem tempItem = puzzle.Item[row][col];
                if (tempItem.Val == currVal)
                    throw new Exception("同一行有相同值");


                if (tempItem.IsConfirmed)
                    continue;

                tempItem.RemoviePossibleVal(currVal);

            }

            // 清除同列的值
            col = j;
            for (row = 0; row < 9; row++)
            {
                if (row == i)
                    continue;

                SudokuItem tempItem = puzzle.Item[row][col];
                if (tempItem.Val == currVal)
                    throw new Exception("同一列有相同值");


                if (tempItem.IsConfirmed)
                    continue;

                tempItem.RemoviePossibleVal(currVal);

            }
            // 清除同块的值
            col = j / 3;
            row = i / 3;
            int rowTml = (row + 1) * 3;
            int colTml = (col + 1) * 3;
            for (int tr = row * 3; tr < rowTml; tr++)
            {
                for (int tc = col * 3; tc < colTml; tc++)
                {
                    if (tr == i && tc == j)
                        continue;

                    SudokuItem tempItem = puzzle.Item[tr][tc];

                    if (tempItem.Val == currVal)
                        throw new Exception("同一框有相同值");


                    if (tempItem.IsConfirmed)
                        continue;

                    tempItem.RemoviePossibleVal(currVal);

                }
            }
            return puzzle;
        }
       
        
        static List<SudokuPuzzle> LoadPuzzles()
        {
            List<SudokuPuzzle> puzzles = new List<SudokuPuzzle>();
            string str = FileReader.ReadFile("p096_sudoku.txt");
            string[] strArray = str.Split('\n');
            for (int i = 0; i < strArray.Length; i += 10)
            {
                if (!strArray[i].Contains("Grid"))
                {
                    continue;
                }
                SudokuPuzzle puzzle = new SudokuPuzzle();
                puzzle.Item = new SudokuItem[9][];
                for (int j = 0; j < 9; j++)
                {
                    puzzle.Item[j] = new SudokuItem[9];
                    int lineIndex = j + i + 1;
                    for (int k = 0; k < 9; k++)
                    {
                        puzzle.Item[j][k] = new SudokuItem();
                        puzzle.Item[j][k].ColumnIndex = k;
                        puzzle.Item[j][k].RowIndex = j;
                        int val = int.Parse(strArray[lineIndex].Substring(k, 1));
                        puzzle.Item[j][k].IsConfirmed = (val != 0);
                        puzzle.Item[j][k].Val = val;
                        if (puzzle.Item[j][k].IsConfirmed)
                            continue;
                        for (int n = 1; n < 10; n++)
                        {
                            puzzle.Item[j][k].AddPossibleVal(n);
                        }
                    }
                }
                puzzles.Add(puzzle);
            }
            return puzzles;
        }
    }
}
