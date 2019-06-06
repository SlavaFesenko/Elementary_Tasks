using System;

namespace NumbersToString_5
{
    internal class Validator
    {
        internal static bool Validate(string[] args, out string message)
        {
            bool isCorrect = false;

            if (IsCorrectCountOfArgs(args, out message))
            {
                int number = ReadIntsFromStrings(args[0], out isCorrect, out message);
                if (isCorrect)
                {
                    isCorrect = IsCorrectInts(number, out message);
                }
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

        private static bool IsCorrectInts(int number, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;
            if (number < 0 || number > 1000000)
            {
                isCorrect = false;
                message = $"Argument {number} is less than zero or more than 1000000!";                   
            }            

            return isCorrect;
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