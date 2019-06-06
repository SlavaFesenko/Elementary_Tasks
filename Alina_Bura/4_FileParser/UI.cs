using System;

namespace FileParser_4
{
    public class UI
    {
        public static void ShowInstruction()
        {
            Console.WriteLine("Input via space:");
            Console.WriteLine("1.File name, string to find");
            Console.WriteLine("2.File name, string to repace, substitude string");
        }

        public static void PrintErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintResult(int count)
        {
            Console.WriteLine(count);
        }
    }
}