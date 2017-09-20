﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Cli
{
    public class Functions
    {
        public static void HelpOutput()
        {
            System.Console.WriteLine("Usuage: sudoku.exe -c <N>");
            System.Console.WriteLine("N is an integer between 1" +
                " and 1000,000(1 and 1000,000 included) which controls" +
                " the number of sudoku's output.");
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
            if (args[0] != "-c")
            {
                Functions.HelpOutput();
                return;
            }
            try
            {
                long num = Int64.Parse(args[1]);
                if (num > 1000000 || num < 0)
                {
                    System.Console.WriteLine("Your input <N> is not " +
                        "between 0 and 1000,000");
                    return;
                }
                using (System.IO.StreamWriter outputfile =
                    new System.IO.StreamWriter(@"sudoku.txt"))
                {
                    outputfile.WriteLine("Test out put file!");
                }
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Input <N> was not in a correct format(integer).");
                return;
            }
        }
    }
}