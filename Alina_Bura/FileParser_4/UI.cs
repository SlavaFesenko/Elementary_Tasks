using System;

namespace FileParser_4
{
    internal class UI
    {
        internal static void ShowInstruction()
        {
            throw new NotImplementedException();
        }

        internal static string[] ReadParameters()
        {
            throw new NotImplementedException();
        }

        internal static int GetMode()
        {
            Console.WriteLine("Select mode:");
            Console.WriteLine("1.Count strings in file");
            Console.WriteLine("2.Replace string in file");
            int mode = int.Parse(Console.ReadLine());
            return mode;
        }

        internal static void PrintErrorMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}