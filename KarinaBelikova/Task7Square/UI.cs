using System;

namespace Task7Square
{
    public class UI
    {
        #region Methods

        public static void PrintSquares(int number)
        {
            SquareNumbers squereSequence = new SquareNumbers(number);
            Console.WriteLine($"Numbers that squares less than {number}: ");
            Console.Write(string.Join(", ", squereSequence.GetSequence()));
            Console.ReadKey();
        }

        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }


        #endregion
    }
}
