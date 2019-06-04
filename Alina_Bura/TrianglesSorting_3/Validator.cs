using System;

namespace TrianglesSorting_3
{
    internal class Validator
    {
        internal static bool Validate(string[] args, out string message)
        {
            bool isCorrect = false;

            if (IsCorrectCountOfArgs(args, out message))
            {
                double[] numbers = ReadDoublesFromStrings(args, out isCorrect, out message);

                if (isCorrect)
                {
                    isCorrect = IsCorrectNumbers(numbers, out message);
                }
            }
            return isCorrect;
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

        private static bool IsCorrectNumbers(double[] numbers, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] <= 0)
                {
                    isCorrect = false;
                    message = $"Argument {numbers[i]} is less than zero!";
                    break;
                }
            }

            return isCorrect;
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