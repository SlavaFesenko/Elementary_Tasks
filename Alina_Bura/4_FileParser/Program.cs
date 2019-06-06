using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateArguments(args);

            switch (args.Length)
            {
                case 2:
                    int count = FileFinder.GetCount(args[0], args[1]);
                    UI.PrintResult(count);
                    break;
                case 3:
                    FileReplacer.ReplaceString(args[0], args[1], args[2]);
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        private static void ValidateArguments(string[] args)
        {
            bool isCorrect = Validator.Validate(args, out string message);
            if (!isCorrect)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    UI.PrintErrorMessage(message);
                }
                UI.ShowInstruction();
            }
        }
    }
}
