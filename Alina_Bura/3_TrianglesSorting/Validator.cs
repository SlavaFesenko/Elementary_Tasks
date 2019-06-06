using System;

namespace TrianglesSorting_3
{
    internal class Validator
    {
        internal static bool Validate(string[] args, out string name, out double[] numbers, out string message)
        {
            bool isCorrect = false;
            name = string.Empty;
            numbers = new double[0];

            if (IsCorrectCountOfArgs(args, out message))
            {
                name = IsCorrectName(args, out isCorrect, out message);
                if (isCorrect)
                {
                    numbers = ReadDoublesFromStrings(args, out isCorrect, out message);
                }
            }
            return isCorrect;
        }

        private static string IsCorrectName(string[] args, out bool isCorrect, out string message)
        {
            isCorrect = true;
            message = string.Empty;

            if (string.IsNullOrEmpty(args[0]))
            {
                isCorrect = false;
                message = $"String {args[0]} is empty!";
            }

            return args[0];
        }

        private static double[] ReadDoublesFromStrings(string[] args, out bool isCorrect, out string message)
        {
            isCorrect = true;
            message = string.Empty;

            double[] numbers = new double[args.Length - 1];

            for (int i = 0; i < args.Length - 1; i++)
            {
                if (!double.TryParse(args[i + 1], out numbers[i]))
                {
                    isCorrect = false;
                    message = $"Argument {args[i + 1]} is not a number!";
                }
            }
            return numbers;
        }

        private static bool IsCorrectCountOfArgs(string[] args, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;

            if (args.Length != 4)
            {
                isCorrect = false;

                if (args.Length != 0)
                {
                    message = "Wrong count of arguments!";
                }
            }

            return isCorrect;
        }
    }
}