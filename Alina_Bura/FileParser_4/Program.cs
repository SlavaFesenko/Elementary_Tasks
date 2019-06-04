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
            bool isCorrect;
            int mode = UI.GetMode();

            isCorrect = Validator.Validate(args, mode, out string message);
            if (!isCorrect)
            {               
                if (!string.IsNullOrEmpty(message))
                {
                    UI.PrintErrorMessage(message);
                }
                
                UI.ShowInstruction();
                args = UI.ReadParameters();
            }

            switch (mode)
            {
                case 1:
                    int count = FileParser.GetCountOfString(args[0], args[1]);
                    break;
                case 2:
                    FileParser.ReplaceString(args[0], args[1], args[2]);
                    break;
                default:
                    break;
            }

        }
    }
}
