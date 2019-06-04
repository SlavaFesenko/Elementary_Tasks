using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalysis
{
    class ConsoleView : IView
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
            Console.WriteLine("reinput");
            ////TODO: ASK About 2-3 elements case Mode?? BUG string with space
            string[] arguments = new string[3];
            //Console.Write("Path to file: ");//TODO: With file name
            //arguments[0] = Console.ReadLine();
            //Console.Write("Search string: ");
            //arguments[1] = Console.ReadLine();

            ////only for replace mode
            //Console.Write("String to replace: ");
            //arguments[2] = Console.ReadLine();

            return arguments;
        }
        #endregion
    }
}
