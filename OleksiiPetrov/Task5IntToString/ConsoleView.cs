using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;

namespace Task5IntToString
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

        public void ShowSeparator()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public string[] ReInput()
        { return null; }

        #endregion
    }
}
