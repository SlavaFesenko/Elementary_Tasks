using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_1
{
    class UIBoard
    {
        public static void BuildUI(string[] args)
        {
            const int RIGHT_ARGS = 1;
            switch (args.Length)
            {
                case RIGHT_ARGS:
                    {
                        try
                        {
                            Board board = Board.Create(int.Parse(args[1]), int.Parse(args[2]));
                            UIBoard.DrowBoard(board);

                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                default:
                    {
                        Instruction();
                        break;
                    }
            }
        }

        public static void DrowBoard(Board board)
        {
            for (int height = 0; height < board.Height; height++)
            {
                for (int width = 0; width < board.Width; width++)
                {
                    if (board.Cells[height, width].Color == Colors.White)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }

                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        private static void Instruction()
        {
            Console.WriteLine("Instructions for working with the program:" + Environment.NewLine +
               "To draw chess boars n*m input 2 natural numbers:");
            Console.ReadLine();
        }
    }
}
