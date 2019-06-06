using System;

namespace Task8Fibonacci
{
    public class UI
    {
        public static void PrintFibonacci(int low, int up)
        {
            Fibonacci fiboSequence = new Fibonacci(low, up);
            Console.WriteLine($"Fibonacci sequence in range {low} - {up}");
            Console.Write(string.Join(", ", fiboSequence.GetSequence()));
            Console.ReadKey();
        }

        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}
