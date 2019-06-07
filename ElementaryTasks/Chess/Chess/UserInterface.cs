using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Chess
{
    public static class UserInterface
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public static void Display(Board userBoard)
        {
            for (int i = 0; i < userBoard.Rows; i++)
            {
                for (int j = 0; j < userBoard.Columns; j++)
                {
                    if (userBoard.CellsTable[i, j].CellColor == ChessBoardColor.Black)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    else
                    {
                        if (userBoard.CellsTable[i, j].CellColor == ChessBoardColor.White)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                    }
                }
                Console.Write("\n");
            }

            _log.Info("The board was drawing.");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void ShowErrorMessage(Exception e)
        {
            _log.Info(e.Message);
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}
