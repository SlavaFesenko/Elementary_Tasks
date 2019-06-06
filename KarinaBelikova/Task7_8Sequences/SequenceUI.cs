using System;

namespace Task7_8Sequences
{
    public class SequenceUI
    {        
        #region Methods

        public static void PrintSquares(int number)
        {
            SquareNumbers squereSequence = new SquareNumbers(number);
            Console.WriteLine($"\nNumbers that squares less than {number}: ");
            Console.Write(string.Join(", ", squereSequence.GetSequence()));            
        }

        public static void PrintFibonacci(int low, int up)
        {
            Fibonacci fiboSequence = new Fibonacci(low, up);
            Console.WriteLine($"\nFibonacci sequence in range {low} - {up}");
            Console.Write(string.Join(", ", fiboSequence.GetSequence()));
            Console.ReadKey();
        }

        public static void ShowInstructionsParams()
        {
            Console.WriteLine("Your input data isn't correct.");
            Console.WriteLine("Please input 2 arguments for 7 Task (Example: 7 125)");
            Console.WriteLine("Or 3 arguments for 8 Task (Example: 8 10 100)");
            Console.ReadKey();
        }

        public static void Incorrect()
        {
            Console.WriteLine("Your input data isn't correct.");
        }

        #endregion
    }
}
