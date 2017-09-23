using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace UnitTestProject1
{
    [TestClass]
    public class SudoTest
    {
        public bool FillSuccess(int[,] puzzle, int i, int j)
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

        // 测试一个数独的有效性
        public void TestValid(int[,] puzzle)
        {
            const int SIZE = 9;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Assert.AreEqual(true, FillSuccess(puzzle, i, j));
                }
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var sudo = new Sudoku.SudokuGenerater();

            sudo.grid = new int[,] {
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

            Assert.AreEqual(true, sudo.FillSuccess(2, 2));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sudo = new Sudoku.SudokuGenerater();

            sudo.grid = new int[,] {
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

            sudo.grid[2, 2] = 4;
            Assert.AreEqual(false, sudo.FillSuccess(2, 2));
        }

        [TestMethod]
        public void TestGenerateFillList1()
        {
            var sudo = new Sudoku.SudokuGenerater();

            using (System.IO.StreamWriter outputfile =
         new System.IO.StreamWriter(@"SudokuTest.txt", true))
            {
                outputfile.WriteLine(String.Join(" ", sudo.GenerateFillList()));
                outputfile.WriteLine(String.Join(" ", sudo.GenerateFillList()));
                outputfile.WriteLine(String.Join(" ", sudo.GenerateFillList()));
                outputfile.WriteLine(String.Join(" ", sudo.GenerateFillList()));
                outputfile.WriteLine(String.Join(" ", sudo.GenerateFillList()));
                outputfile.WriteLine();
            }
        }

        [TestMethod]
        public void TestASudok1()
        {
            int[,] puzzle = {
                {5, 3, 7, 2, 4, 9, 6, 8, 1},
                {8, 2, 9, 5, 6, 3, 7, 1, 4},
                {9, 1, 6, 4, 7, 5, 3, 2, 8},
                {2, 8, 1, 6, 9, 7, 4, 5, 3},
                {4, 9, 5, 8, 3, 1, 2, 7, 6}, // 6
                {7, 6, 3, 9, 1, 2, 8, 4, 5},
                {3, 5, 4, 7, 2, 8, 1, 6, 9},
                {1, 4, 2, 3, 8, 6, 5, 9, 7},
                {6, 7, 8, 1, 5, 4, 9, 3, 2}
                };
            TestValid(puzzle);
        }

        [TestMethod]
        public void TestASudok2()
        {
            int[,] puzzle = {
                {5, 3, 7, 2, 4, 9, 6, 8, 1},
                {8, 2, 9, 5, 6, 3, 7, 1, 4},
                {9, 1, 6, 4, 7, 5, 3, 2, 8},
                {2, 8, 1, 6, 9, 7, 4, 5, 3},
                {4, 9, 5, 8, 3, 1, 2, 7, 6},
                {7, 6, 3, 1, 2, 4, 8, 9, 5},
                {6, 7, 4, 9, 1, 8, 5, 3, 2},
                {3, 5, 2, 7, 8, 6, 1, 4, 9},
                {1, 4, 8, 3, 5, 2, 9, 6, 7}
                };
            TestValid(puzzle);
        }
    }
}
