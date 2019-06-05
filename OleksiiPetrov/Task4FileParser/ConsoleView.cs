using SharedLibrary;
using System;

namespace Task4FileParser
{
    public class ConsoleView : IView
    {
        #region Methods

        public void ShowErrorMessage(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ResetColor();
        }

        public void ShowInstruction(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ShowSeparator();
            Console.WriteLine(text);
            ShowSeparator();
            Console.WriteLine();
            Console.ResetColor();
        }

        public void ShowResult(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ShowSeparator();
            Console.WriteLine(text);
            ShowSeparator();
            Console.WriteLine();
            Console.ResetColor();
        }

        public void ShowSeparator()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public string[] ReInput()
        {
            string[] arguments = new string[3];

            Console.WriteLine("Input in stages:");
            ShowSeparator();
            Console.WriteLine("Press 1 to Find mode or press 2 to Replace modes");
            ConsoleKeyInfo key = Console.ReadKey();
            
            if(key.Key.Equals(ConsoleKey.D1))
            {
                Console.Write("\nPath to file: ");
                arguments[0] = Console.ReadLine();
                Console.Write("Searching string: ");
                arguments[1] = Console.ReadLine();
            }
            if (key.Key.Equals(ConsoleKey.D2))
            {
                Console.Write("\nPath to file: ");
                arguments[0] = Console.ReadLine();
                Console.Write("Searching string: ");
                arguments[1] = Console.ReadLine();
                Console.Write("String to replace: ");
                arguments[2] = Console.ReadLine();
            }

            return arguments;
        }

        #endregion
    }
}
