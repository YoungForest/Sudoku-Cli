using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku;
using System.Diagnostics;

namespace Sudoku_Cli
{
    public class Functions
    {
        public static void HelpOutput()
        {
            System.Console.WriteLine("Usuage1: sudoku.exe -c <N>");
            System.Console.WriteLine("N is an integer between 1" +
                " and 1000,000(1 and 1000,000 included) which controls" +
                " the number of sudoku's output.");
            System.Console.WriteLine();
            System.Console.WriteLine("Usuage2: sudoku.exe -s <absolute_path_of_puzzlefile>");
            System.Console.WriteLine("<absolute_path_of_puzzlefile> is " +
                "a text file containing the puzzles of sudoku you" +
                " want to solve");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 输入处理
            if (args.Length != 2)
            {
                System.Console.WriteLine("{0} arguments detected.", args.Length);
                Functions.HelpOutput();
                return;
            }
            if (args[0] == "-c")
            {
                try
                {
                    int num = Int32.Parse(args[1]);
                    if (num > 1000000 || num < 1)
                    {
                        System.Console.WriteLine("Your input <N> is not " +
                            "between 0 and 1000,000");
                        return;
                    }

                    // clear the content of sudoku.txt
                    using (System.IO.StreamWriter outputfile =
             new System.IO.StreamWriter(@"sudoku.txt"))
                    {
                        outputfile.Write("");
                    }

                    // begin generate
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var sudo = new Sudoku.SudokuGenerater();

                    sudo.bound = num;
                    sudo.grid[0, 0] = 5;
                    try
                    {
                        sudo.FillNextGrid(0, 1);
                    }
                    catch (Sudoku.EnoughResultsException ex)
                    {
                        System.Console.WriteLine(ex);
                    }
                    stopWatch.Stop();
                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopWatch.Elapsed;

                    // Format and display the TimeSpan value.
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                }
                catch (System.FormatException)
                {
                    System.Console.WriteLine("Input <N> was not in a correct format(integer).");
                    return;
                }
            }
            else if (args[0] == "-s")
            {
                // sudoku solve
            }
            else
            {
                Functions.HelpOutput();
                return;
            }
        }
    }
}
