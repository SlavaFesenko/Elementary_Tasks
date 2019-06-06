using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7Square
{
    public class SquareUI
    {
        #region Methods

        public static void PrintSquares(int number)
        {
            SquareNumbers squereSequence = new SquareNumbers(number);
            Console.WriteLine($"\nNumbers that squares less than {number}: ");
            Console.Write(string.Join(", ", squereSequence.GetSequence()));
        }        

        public static void ShowInstructionsParams()
        {
            Console.WriteLine("Your input data isn't correct.");
            Console.WriteLine("Please input pozitive number (Example: 125)");
            Console.ReadKey();
        }

        public static void Incorrect()
        {
            Console.WriteLine("Your input data isn't correct.");
        }

        #endregion
    }
}
