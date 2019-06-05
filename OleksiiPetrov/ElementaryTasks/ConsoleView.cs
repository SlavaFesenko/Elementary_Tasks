using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTasks
{
    public class ConsoleView: IView
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
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ResetColor();
        }

        public string[] ReInput()
        {
            string inputValue = Console.ReadLine();
            string[] arguments = inputValue.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return arguments;
        }
        #endregion
    }
}
