using System;

namespace Envelops_2
{
    class Validator
    {
        public static bool Validate(double[] parameters, out string message)
        {
            bool isCorrect = false;

            if (IsCorrectCountOfArgs(parameters, out message))
            {
                isCorrect = IsCorrectNumbers(parameters, out message);                
            }
            return isCorrect;
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

        private static bool IsCorrectCountOfArgs(double[] parameters, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;

            if (parameters.Length != 4)
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