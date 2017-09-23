using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuSolver
    {
        public int[,] puzzle = new int[9, 9];
        public const int SIZE = 8;

        public void ReadIntoPuzzle(string[] lines)
        {
            for (int i = 0; i <= SIZE; i++)
            {
                char[] delimiterChars = { ' ' };
                string[] words = lines[i].Split(delimiterChars);

                for (int j = 0; j <= SIZE; j++)
                {
                    try
                    {
                        puzzle[i, j] = Int32.Parse(words[j]);
                    }
                    catch (FormatException ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void FillNextpuzzle(int i, int j)
        {
            if (puzzle[i, j] != 0)
            {
                if (i == SIZE && j == SIZE)
                {
                    throw new PuzzleCompleteException();
                }
                else
                {
                    int nexti = j == SIZE ? i + 1 : i;
                    int nextj = j == SIZE ? 0 : j + 1;
                    FillNextpuzzle(nexti, nextj);
                    return;
                }
            }

            var sudokuGenerater = new SudokuGenerater();
            var fillList = sudokuGenerater.GenerateFillList();

            fillList.ForEach(delegate (int item)
            {
                puzzle[i, j] = item;
                if (FillSuccess(i, j))
                {
                    if (i == SIZE && j == SIZE)
                    {
                        throw new PuzzleCompleteException();
                    }
                    else
                    {
                        int nexti = j == SIZE ? i + 1 : i;
                        int nextj = j == SIZE ? 0 : j + 1;
                        FillNextpuzzle(nexti, nextj);
                    }
                }
                else
                {
                    puzzle[i, j] = 0;
                }
            });
            puzzle[i, j] = 0;
        }

        public void Solve()
        {
            try
            {
                FillNextpuzzle(0, 0);
            }
            catch (PuzzleCompleteException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public void AppendResultToFile(string v, bool space)
        {
            using (System.IO.StreamWriter outputfile =
         new System.IO.StreamWriter(v, true))
            {
                if (space)
                    outputfile.WriteLine();
                for (int i = 0; i <= SIZE; i++)
                {
                    for (int j = 0; j <= SIZE; j++)
                    {
                        outputfile.Write("{0} ", puzzle[i, j]);
                    }
                    outputfile.WriteLine();
                }
            }
        }

        public bool FillSuccess(int i, int j)
        {
            // check column
            for (int ii = i - 1; ii >= 0; ii--)
            {
                if (puzzle[i, j] == puzzle[ii, j])
                    return false;
            }

            // check row
            for (int jj = j - 1; jj >= 0; jj--)
            {
                if (puzzle[i, j] == puzzle[i, jj])
                    return false;
            }
            // check small puzzle
            int basei = i - i % 3;
            int basej = j - j % 3;
            for (int ii = basei; ii < basei + 3 && ii < i; ii++)
            {
                for (int jj = basej; jj < basei + 3 && jj < j; jj++)
                {
                    if (puzzle[i, j] == puzzle[ii, jj])
                        return false;
                }
            }

            return true;
        }
    }
}
