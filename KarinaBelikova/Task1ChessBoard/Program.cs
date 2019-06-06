using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardApp
{
    class Program
    {
        static void Main(string[] args)
        {          
            if(Validator.IsCorrect(args))
            {
                int rows = int.Parse(args[0]);
                int columns = int.Parse(args[1]);

                UI.Print(rows, columns);
            } 
            else
            {
                UI.ShowInstructions();
            }

            Console.ReadKey();
        }
    }
}
