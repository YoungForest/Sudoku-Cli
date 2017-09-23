using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuLibrary;

namespace SimpleApplication
{
    class Funcation
    {
        // 测试一个数独的有效性
        public static void TestValid(int[,] puzzle)
        {
            const int SIZE = 9;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (SudokuLibrary.SudokuTest.FillSuccess(puzzle, i, j) == false)
                    {
                        throw new Exception();
                    }
                }
            }
        }

        public static void TestSudoku0()
        {
            int[,] grid = new int[,] {
                { 2, 6, 8, 4, 7, 3, 9, 5, 1},
                { 3, 4, 1, 9, 6, 5, 2, 7, 8},
                { 7, 9, 5, 8, 1, 2, 3, 6, 4},
                { 5, 7, 4, 6, 2, 1, 8, 3, 9},
                { 1, 3, 9, 5, 4, 8, 6, 2, 7},
                { 8, 2, 6, 3, 9, 7, 4, 1, 5},
                { 9, 1, 7, 2, 8, 6, 5, 4, 3},
                { 6, 8, 3, 1, 5, 4, 7, 9, 2},
                { 4, 5, 2, 7, 3, 9, 1, 8, 6}
            };

            TestValid(grid);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Funcation.TestSudoku0();
        }
    }
}
