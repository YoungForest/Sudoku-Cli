using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
{
    public class SudokuGenerater
    {
        // 2 !8 = 29666
        public int[,] grid = new int[9, 9];
        const int LAST = 8;
        public int count = 0;
        public int bound = 0;
        
        public void FillNextGrid(int i, int j)
        {
            var fillList = SudokuTest.GenerateFillList();

            fillList.ForEach(delegate (int item)
            {
                grid[i, j] = item;
                if (SudokuTest.FillSuccess(grid, i, j))
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
            });
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

    }
}
