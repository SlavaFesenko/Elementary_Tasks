using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Validator
    {
        public static bool IsValidNumber(string number, out int result)
        {
            return Int32.TryParse(number, out result) && result >= 1 && result <= 32;
        }

        public static bool IsLenghtArgsInvalid(string [] args)
        {
            return args.Length != 2;
        }

        public static bool IsValidArgs(string [] args, out int firstArgument, out int secondArgument)
        {
            bool isFirstArgValid = Validator.IsValidNumber(args[0], out firstArgument);
            bool isSecondArgValid = Validator.IsValidNumber(args[1], out secondArgument);

            return isFirstArgValid && isSecondArgValid;
        }
    }
}
