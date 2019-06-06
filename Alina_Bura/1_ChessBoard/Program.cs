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
            try
            {
                bool isCorrect = GetParameters(args, out int rows, out int columns);
                if (isCorrect)
                {
                    ChessBoard chessBoard = new ChessBoard(rows, columns);
                    Controller controller = new Controller(chessBoard);
                    controller.PrintBoard();
                }
            }
            catch (ArgumentException ex)
            {
                UI.PrintErrorMessage(ex.Message);
            }
            catch (CaseNotFoundException ex)
            {
                UI.PrintErrorMessage(ex.Message);
            }

            Console.ReadKey();            
        }
        
        private static bool GetParameters(string[] args, out int rows, out int columns)
        {
            bool isCorrect = Validator.Validate(args, out rows, out columns, out string message);

            if (!isCorrect)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    UI.PrintErrorMessage(message);
                }
                UI.ShowInstruction();
                Console.ReadLine();
            }

            return isCorrect;
        }
    }
}
