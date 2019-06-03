using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
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
                UserInteface.Display(myBoard);
                             
            }
            catch (ArgumentException e)
            {
                UserInteface.ShowErrorMessage(e);
            }
            catch (FormatException e)
            {
                UserInteface.ShowErrorMessage(e);
            }
        }

        #endregion
    }
}
