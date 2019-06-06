using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Fibonacci
{
    class FibonacciUI
    {
        #region Methods       

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
            Console.WriteLine("Input 2 numbers for 8 Task (Example: 10 100)");
            Console.ReadKey();
        }

        public static void Incorrect()
        {
            Console.WriteLine("Your input data isn't correct.");
        }

        #endregion
    }
}
