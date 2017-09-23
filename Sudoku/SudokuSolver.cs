using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
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

            var fillList = SudokuTest.GenerateFillList();

            fillList.ForEach(delegate (int item)
            {
                puzzle[i, j] = item;
                if (SudokuTest.FillSuccess(puzzle, i, j))
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
            });
            throw new SolverFailException();
        }

        public void Solve()
        {
            try
            {
                FillNextpuzzle(0, 0);
            }
            catch (PuzzleCompleteException ex)
            {
                System.Console.WriteLine(ex);
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
    }

    [Serializable]
    internal class SolverFailException : Exception
    {
        public SolverFailException()
        {
        }

        public SolverFailException(string message) : base(message)
        {
        }

        public SolverFailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SolverFailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
