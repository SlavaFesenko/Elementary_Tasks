using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalysis
{
    class ConsoleView : IView
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

        private void ShowSeparator()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public void ShowMessage(string text)
        {
            ShowSeparator();
            Console.WriteLine(text);
            ShowSeparator();
        }

        public string Input(string text)
        {
            Console.Write(text);

            return Console.ReadLine();
        }

        #endregion
    }
}
