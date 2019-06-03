using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public static class UserInteface
    {
        public static void Display(Board userBoard)//TODO: Pattern builder
        {
            for (int i = 0; i < userBoard.Rows; i++)
            {
                for (int j = 0; j < userBoard.Columns; j++)
                {
                    if (userBoard.CellsTable[i, j].CellColor == ChessBoardColors.Black)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    else
                    {
                        if (userBoard.CellsTable[i, j].CellColor == ChessBoardColors.White)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                    }
                }
                Console.Write("\n");
            }

            Console.ResetColor();
            Console.ReadLine();
        }

        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}
