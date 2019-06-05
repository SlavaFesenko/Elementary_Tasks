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
            ShowSeparator();
            Console.WriteLine(text);
            ShowSeparator();
            Console.WriteLine();
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

        private void ShowSeparator()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public string[] ReInput()
        {
            Console.Write("Please input correct: ");
            string[] arguments = Console.ReadLine().Split();

            return arguments;
        }

        #endregion
    }
}
