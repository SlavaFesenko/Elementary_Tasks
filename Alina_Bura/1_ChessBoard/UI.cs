using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeFirstTasks
{
    static class UI 
    {        
        public static void PrintBoard(int r, int c, ConsoleColor[,] backColors, ConsoleColor[,] foreColors, char[,] symbols)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.BackgroundColor = backColors[i, j];
                    Console.ForegroundColor = foreColors[i, j];
                    Console.Write(symbols[i, j]); 
                }
                Console.WriteLine();
            }
        }

        public static void PrintErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowInstruction()
        {
            Console.WriteLine("Input 2 integer values more then 0 via space");
            Console.WriteLine("First value is height, second value is width");
        }
    }
}
