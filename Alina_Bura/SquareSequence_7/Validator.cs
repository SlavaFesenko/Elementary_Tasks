using System;

namespace SquareSequence_7
{
    internal class Validator
    {
        internal static bool Validate(string[] args, out string message, out int number)
        {
            bool isCorrect = false;
            number = 0;

            if (IsCorrectCountOfArgs(args, out message))
            {
                number = ReadIntsFromStrings(args[0], out isCorrect, out message);                
            }
            return isCorrect;
        }

        private static int ReadIntsFromStrings(string arg, out bool isCorrect, out string message)
        {
            isCorrect = true;
            message = string.Empty;

            if (!int.TryParse(arg, out int number))
            {
                isCorrect = false;
                message = $"Argument {arg} is not integer number!";
            }

            return number;
        } 

        private static bool IsCorrectCountOfArgs(string[] parameters, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;

            if (parameters.Length != 1)
            {
                isCorrect = false;

                if (parameters.Length != 0)
                {
                    message = "Wrong count of arguments!";
                }
            }

            return isCorrect;
        }
    }
}