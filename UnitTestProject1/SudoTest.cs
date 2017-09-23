using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class SudoTest
    {
        // 测试一个数独的有效性
        public void TestValid(int[,] puzzle)
        {
            const int SIZE = 9;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    var real = SudokuTest.FillSuccess(puzzle, i, j);
                    if (real == false)
                    {
                        // clear the content of sudoku.txt
                        using (System.IO.StreamWriter outputfile =
                 new System.IO.StreamWriter(@"ErrorLog.txt", true))
                        {
                            outputfile.Write("i = {0}, j = {1};", i, j);
                        }
                    }
                    Assert.AreEqual(true, real);
                }
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            int [,] grid = new int[,] {
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

            Assert.AreEqual(true, SudokuTest.FillSuccess(grid, 2, 2));
        }

        [TestMethod]
        public void TestMethod2()
        {
            int [,] grid = new int[,] {
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

            grid[2, 2] = 4;
            Assert.AreEqual(false, SudokuTest.FillSuccess(grid, 2, 2));
        }

        [TestMethod]
        public void TestSudoku0()
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

        [TestMethod]
        public void TestASudok1()
        {
            int[,] puzzle = {
                {5, 8, 1, 2, 7, 3, 9, 6, 4},
                {9, 6, 4, 1, 5, 8, 3, 2, 7},
                {2, 3, 7, 6, 4, 9, 8, 5, 1},
                {1, 7, 9, 3, 6, 5, 2, 4, 8},
                {3, 5, 2, 9, 8, 4, 7, 1, 6},
                {6, 4, 8, 7, 1, 2, 5, 3, 9},
                {8, 9, 6, 5, 2, 1, 4, 7, 3},
                {4, 1, 5, 8, 3, 7, 6, 9, 2},
                {7, 2, 3, 4, 9, 6, 1, 8, 5}
                };

            TestValid(puzzle);
        }

        [TestMethod]
        public void TestASudok2()
        {
            int[,] puzzle = {
                {5, 8, 1, 2, 7, 3, 9, 6, 4},
                {9, 6, 4, 1, 5, 8, 3, 2, 7},
                {2, 3, 7, 6, 4, 9, 8, 5, 1},
                {1, 7, 9, 3, 6, 5, 2, 4, 8},
                {3, 5, 2, 9, 8, 4, 7, 1, 6},
                {6, 4, 8, 7, 1, 2, 5, 3, 9},
                {8, 9, 6, 5, 3, 1, 4, 7, 2},
                {7, 2, 5, 4, 9, 6, 1, 8, 3},
                {4, 1, 3, 8, 2, 7, 6, 9, 5}
                };
            TestValid(puzzle);
        }
    }
}
