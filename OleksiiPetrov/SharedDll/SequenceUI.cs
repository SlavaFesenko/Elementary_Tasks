using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDll
{
    public class SequenceUI : IView
    {
        private const string LINE_SEPARATOR = "---------------------------------------------------------------------------";

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
            Console.WriteLine(LINE_SEPARATOR);
            Console.WriteLine(text);
            Console.WriteLine(LINE_SEPARATOR);
            Console.WriteLine();
        }

        public void ShowResult(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(LINE_SEPARATOR);
            Console.WriteLine(text);
            Console.WriteLine(LINE_SEPARATOR);
            Console.WriteLine();
            Console.ResetColor();
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
