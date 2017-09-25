using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class FastSudokuGenerater
    {
        static Puzzle[] mothers;
        static HashSet<int> sudokuSets = new HashSet<int>();

        public static void Initial()
        {
            mothers = new Puzzle[3];
            var grids1 = new int[,] {
                {5, 8, 1, 4, 2, 3, 6, 9, 7},
                {4, 9, 3, 1, 7, 6, 8, 5, 2},
                {6, 7, 2, 8, 5, 9, 1, 4, 3},
                {3, 1, 4, 2, 8, 7, 5, 6, 9},
                {8, 5, 9, 3, 6, 4, 7, 2, 1},
                {7, 2, 6, 9, 1, 5, 4, 3, 8},
                {9, 3, 5, 7, 4, 1, 2, 8, 6},
                {1, 6, 8, 5, 3, 2, 9, 7, 4},
                {2, 4, 7, 6, 9, 8, 3, 1, 5}
                };
            mothers[0] = new Puzzle(grids1);

            var grids2 = new int[,] {
                {5, 4, 8, 3, 7, 2, 1, 6, 9},
                {7, 2, 9, 8, 6, 1, 4, 3, 5},
                {6, 3, 1, 5, 4, 9, 8, 7, 2},
                {4, 5, 2, 7, 9, 8, 6, 1, 3},
                {8, 1, 7, 2, 3, 6, 9, 5, 4},
                {3, 9, 6, 4, 1, 5, 2, 8, 7},
                {9, 6, 4, 1, 5, 3, 7, 2, 8},
                {1, 8, 5, 9, 2, 7, 3, 4, 6},
                {2, 7, 3, 6, 8, 4, 5, 9, 1}
                };
            mothers[1] = new Puzzle(grids2);

            var grids3 = new int[,] {
                {5, 7, 8, 1, 2, 9, 4, 3, 6},
                {9, 6, 3, 8, 5, 4, 2, 7, 1},
                {1, 4, 2, 3, 7, 6, 9, 5, 8},
                {3, 2, 4, 7, 6, 8, 5, 1, 9},
                {6, 8, 9, 5, 4, 1, 7, 2, 3},
                {7, 5, 1, 2, 9, 3, 8, 6, 4},
                {4, 9, 7, 6, 1, 2, 3, 8, 5},
                {8, 1, 5, 4, 3, 7, 6, 9, 2},
                {2, 3, 6, 9, 8, 5, 1, 4, 7},
                };
            mothers[2] = new Puzzle(grids3);
        }

            
        static bool Unique(int [,] v)
        {
            var hashCode = v.GetHashCode();

            if (sudokuSets.Contains(hashCode))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static System.Collections.Generic.IEnumerable<int[,]> Next()
        {
            int[,] now;
            for (int i = 0; i < 3; i++)
            { // 母数独
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                        now = ExchangeColumn(mothers[i].grids, 1, 2);
                    else
                        now = mothers[i].grids;
                    yield return now;
                }
            }
        }

        public static System.Collections.Generic.IEnumerable<int[,]> Exchange3ColumnMid(int [,] v)
        {
            var v1 = ExchangeColumn(v, 3, 4);
            var v2 = ExchangeColumn(v, 3, 5);
            var v3 = ExchangeColumn(v, 4, 5);
            var v4 = ExchangeColumn(v1, 4, 5);
            var v5 = ExchangeColumn(v2, 4, 5);
            var v6 = v;

            return Exchange3ColumnRight(v1);
        }

        public static System.Collections.Generic.IEnumerable<int[,]> Exchange3ColumnRight(int[,] v)
        {
            var v1 = ExchangeColumn(v, 6, 7);
            var v2 = ExchangeColumn(v, 6, 8);
            var v3 = ExchangeColumn(v, 7, 8);
            var v4 = ExchangeColumn(v1, 7, 8);
            var v5 = ExchangeColumn(v2, 7, 8);
            var v6 = v;

            return Exchange3ColumnRight(v1);
        }

        static int [,] ExchangeColumn(int [,] mother, int column1, int column2)
        {
            int[,] re = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == column1)
                        re[i, column1] = mother[i, column2];
                    else if (j == column2)
                        re[i, column2] = mother[i, column1];
                    else
                        re[i, j] = mother[i, j];
                }
            }
            return re;
        }

        static int[,] ExchangeRow(int[,] mother, int row1, int row2)
        {
            int[,] re = new int[9, 9];
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i == row1)
                        re[row1, j] = mother[row2, j];
                    else if (i == row2)
                        re[row2, j] = mother[row1, j];
                    else
                        re[i, i] = mother[i, i];
                }
            }
            return re;
        }
    }

    class Puzzle
    {
        public int[,] grids;

        public Puzzle(int [,] v1)
        {
            grids = v1;
        }
    }
}
