using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Chess
{
    public class Program
    {
        public static void Main(string[] args)
        {           
           Run(args);           
        }

        #region Method

        public static void Run(string[] args)
        {
            Console.WriteLine("USE FORMAT: <rows> <columns>");
            Logger log = LogManager.GetCurrentClassLogger();

            try
            {
                log.Info($"User input {args[0]} {args[1]}.");
                (int rows, int columns) = Validator.Validate(args);               
                Board myBoard = new Board(rows, columns);
                UserInterface.Display(myBoard);               
            }
            catch (ArgumentNullException e)
            {
                UserInterface.ShowErrorMessage(e);
                log.Error($"ArgumentNullException: {e.Message}");
            }
            catch (ArgumentException e)
            {
                UserInterface.ShowErrorMessage(e);
                log.Error($"ArgumentException: {e.Message}");
            }
            catch (FormatException e)
            {
                UserInterface.ShowErrorMessage(e);
                log.Error($"FormatException: {e.Message}");
            }
        }

        #endregion
    }
}
