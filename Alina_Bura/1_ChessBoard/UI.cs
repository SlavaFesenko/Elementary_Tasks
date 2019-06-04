using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeFirstTasks
{
    static class UI 
    {        
        public static void PrintBoard(int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.BackgroundColor = _controller.GetBackColorForCell(i, j);
                    Console.ForegroundColor = _controller.GetForeColorForCell(i, j);
                    Console.Write(_controller.GetSymbolForCell(i, j)); // interface iboard
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
