using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeFirstTasks
{
    static class Validator
    {
        public static bool Validate(string[] args, out string message)
        {
            bool isCorrect = false;

            if (IsCorrectCountOfArgs(args, out message))
            {
                int[] numbers = ReadIntsFromStrings(args, out isCorrect, out message);
                if (isCorrect)
                {
                    isCorrect = IsCorrectInts(numbers, out message);
                }
            }
            return isCorrect;
        }

        private static int[] ReadIntsFromStrings(string[] args, out bool isCorrect, out string message)
        { 
            isCorrect = true;
            message = string.Empty;

            int[] numbers = new int[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                if (!int.TryParse(args[i], out numbers[i]))
                {
                    isCorrect = false;
                    message = $"Argument {args[i]} is not integer number!";
                }
            }
            return numbers;
        }

        private static bool IsCorrectInts(int[] numbers, out string message)
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

            if (args.Length != 2)
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
