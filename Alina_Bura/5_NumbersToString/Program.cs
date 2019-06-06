using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToString_5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = GetNumber(args, out bool isCorrect);
                if (isCorrect)
                {
                    NumberParser n = new NumberParser(ParserHelper.InitDictionary("numbers.txt"));

                    UI.ShowResult(n.ToString(number));
                }                
            }
            catch (FileNotFoundException ex)
            {
                UI.PrintErrorMessage(ex.Message);
            }
            Console.ReadLine();
        }

        private static int GetNumber(string[] args, out bool isCorrect)
        {
            isCorrect = Validator.Validate(args, out int number, out string message);
            if (!isCorrect)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    UI.PrintErrorMessage(message);
                }
                UI.ShowInstruction();
            }

            return number;
        }
    }
}
