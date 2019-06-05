using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            try
            {
                (int rows, int columns) = Validator.Validate(args);               
                Board myBoard = new Board(rows, columns);
                UserInterface.Display(myBoard);                            
            }
            catch (ArgumentNullException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
            catch (ArgumentException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
            catch (FormatException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
        }

        #endregion
    }
}
