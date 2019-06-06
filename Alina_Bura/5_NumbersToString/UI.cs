using System;

namespace NumbersToString_5
{
    public class UI
    {
        public static void ShowInstruction()
        {
            Console.WriteLine("Input integer number less or equals 1,000,000");
        }

        public static void ShowResult(string result)
        {
            Console.WriteLine(result);
        }

        public static void PrintErrorMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}