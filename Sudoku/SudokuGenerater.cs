using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuGenerater
    {
        // 2 !8 = 29666
        public int[,] grid = new int[9, 9];
        const int LAST = 8;
        public int count = 0;
        public int bound = 0;
        public Random rnd = new Random();
        public int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public void FillNextGrid(int i, int j)
        {
            var fillList = GenerateFillList();

            fillList.ForEach(delegate (int item)
            {
                grid[i, j] = item;
                if (FillSuccess(i, j))
                {
                    if (i == LAST && j == LAST)
                    {
                        PrintResult();
                        return;
                    }
                    else
                    {
                        int nexti = j == LAST ? i + 1 : i;
                        int nextj = j == LAST ? 0 : j + 1;
                        FillNextGrid(nexti, nextj);
                    }
                }
                else
                {
                    grid[i, j] = 0;
                }
            });
            grid[i, j] = 0;
        }

        private void PrintResult()
        {
            using (System.IO.StreamWriter outputfile =
         new System.IO.StreamWriter(@"sudoku.txt", true))
            {
                if (count != 0)
                    outputfile.WriteLine();
                for (int i = 0; i <= LAST; i++)
                {
                    for (int j = 0; j <= LAST; j++)
                    {
                        outputfile.Write("{0} ", grid[i, j]);
                    }
                    outputfile.WriteLine();
                }
            }
            count++;
            if (count >= bound)
                throw new EnoughResultsException();
        }

        public bool FillSuccess(int i, int j)
        {
            // check column
            for (int ii = i - 1; ii >= 0; ii--)
            {
                if (grid[i, j] == grid[ii, j])
                    return false;
            }

            // check row
            for (int jj = j - 1; jj >= 0; jj--)
            {
                if (grid[i, j] == grid[i, jj])
                    return false;
            }
            // check small grid
            int basei = i - i % 3;
            int basej = j - j % 3;
            for (int ii = basei; ii < basei + 3 && ii < i; ii++)
            {
                for (int jj = basej; jj < basei + 3 && jj < j; jj++)
                {
                    if (grid[i, j] == grid[ii, jj])
                        return false;
                }
            }

            return true;
        }

        // randomly generate a list containing 1 to 9
        public List<int> GenerateFillList()
        {
            int[] MyRandomNumbers = numbers.OrderBy(x => rnd.Next()).ToArray();

            return MyRandomNumbers.ToList();
        }
    }
}
