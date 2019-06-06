using System;

namespace NumbersToString_5
{
    public class Validator
    {
        public static bool Validate(string[] args, out int number, out string message)
        {
            bool isCorrect = false;
            number = 0;

            if (IsCorrectCountOfArgs(args, out message))
            {
                number = ReadIntsFromStrings(args[0], out isCorrect, out message);
                if (isCorrect)
                {
                    isCorrect = IsCorrectInts(number, out message);
                }
            }
            return isCorrect;
        }

        public static int ReadIntsFromStrings(string arg, out bool isCorrect, out string message)
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

        public static bool IsCorrectInts(int number, out string message)
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

        public static bool IsCorrectCountOfArgs(string[] parameters, out string message)
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