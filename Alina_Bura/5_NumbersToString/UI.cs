using System;

namespace NumbersToString_5
{
    internal class UI
    {
        internal static void ShowInstruction()
        {
            Console.WriteLine("Input integer number less or equals 1,000,000");
        }

        internal static void ShowResult(string result)
        {
            Console.WriteLine(result);
        }

        internal static void PrintErrorMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}