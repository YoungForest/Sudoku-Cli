using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace UnitTestProject1
{
    [TestClass]
    public class SudoTest
    {
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
    }
}
