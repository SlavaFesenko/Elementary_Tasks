 using System;

namespace ElementaryTasks
{
    public class ConsoleUI : IDraw
    {
        public void Draw(ISurface board)
        {
            Console.Clear();
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.Cells[i, j].IsDark)
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
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
