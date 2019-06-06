using System;

namespace ChessBoardApp
{
    public class BoardUI
    {
        public static void Print(int rows, int columns)
        {
            Board chessBoard = new Board(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (chessBoard._cells[i, j].Color == Color.Black)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

            Console.ResetColor();                        
        }

        public static void ShowInstructions()
        {
            string instructions = String.Format("Your input data isn't correct.\nPlease input 2 arguments (width and height of the board)");
            Console.WriteLine(instructions);
        }
    }
}
