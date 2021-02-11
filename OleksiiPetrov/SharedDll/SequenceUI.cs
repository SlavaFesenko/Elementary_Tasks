using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class SequenceUI : IView
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
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ShowSeparator();
            Console.WriteLine(text);
            ShowSeparator();
            Console.WriteLine();
            Console.ResetColor();
        }

        public void ShowResult(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            ShowSeparator();
            Console.WriteLine(text);
            ShowSeparator();
            Console.WriteLine();
            Console.ResetColor();
        }

        private void ShowSeparator()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public string[] ReInput()
        {
            Console.WriteLine("Press Enter to ReInput mode or Escape(esc) to EXIT");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key.Equals(ConsoleKey.Escape))
                Environment.Exit(0);
            else
                if (key.Key.Equals(ConsoleKey.Enter))
            {
                Console.Write("Please input correct: ");
                string[] arguments = Console.ReadLine().Split();
                return arguments;
            }
            else
            {
                ShowErrorMessage("\nInvalid input.");
                ReInput();
            }

            return null;
        }

        #endregion
    }
}
