using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Validator
    {
        public static bool IsNumber(string number)
        {
            return Int32.TryParse(number, out int result);
        }

        public static bool IsLenghtArgsInvalid(string [] args)
        {
            return args.Length != 2;
        }

        public static bool IsValidArgs(string [] args)
        {
            bool isFirstArgValid = Validator.IsNumber(args[0]);
            bool isSecondArgValid = Validator.IsNumber(args[1]);

            return isFirstArgValid && isSecondArgValid;
        }
    }
}
