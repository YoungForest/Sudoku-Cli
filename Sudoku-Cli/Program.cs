using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku;

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
                int num = Int32.Parse(args[1]);
                if (num > 1000000 || num < 1)
                {
                    System.Console.WriteLine("Your input <N> is not " +
                        "between 0 and 1000,000");
                    return;
                }

                var sudo = new Sudoku.Sudo();

                sudo.bound = num;
                sudo.grid[0,0] = 5;
                try
                {
                    sudo.FillNextGrid(0, 1);
                }
                catch (Sudoku.EnoughResultsException ex)
                {
                    System.Console.WriteLine(ex);
                }
                System.Console.WriteLine("End of Program");
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Input <N> was not in a correct format(integer).");
                return;
            }
        }
    }
}
