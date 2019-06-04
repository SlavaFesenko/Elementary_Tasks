using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeFirstTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect;

            isCorrect = Validator.Validate(args, out string message);
            if (!isCorrect)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    UI.PrintErrorMessage(message);
                }
                UI.ShowInstruction();
                Console.ReadLine();

                return;
            }
            
            int rows = int.Parse(args[0]);
            int columns = int.Parse(args[1]);

            try
            {
                ChessBoard chessBoard = new ChessBoard(rows, columns);
                Controller controller = new Controller(chessBoard);
                controller.PrintBoard();
            }
            catch (CaseNotFoundException ex)
            {
                UI.PrintErrorMessage(ex.Message);
            }

            Console.ReadKey();            
        }
    }
}
