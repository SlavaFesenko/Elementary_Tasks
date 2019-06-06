using System;
using System.IO;

namespace LuckyTickets_6
{
    public class Validator
    {
        public static bool Validate(string[] args, int digitsCount, int[] range, out string message)
        {
            return IsCorrectCountOfArgs(args, out message) && IsCorrectFile(args[0], out message)
                && IsCorrectDigits(digitsCount, out message) && IsCorrectRange(range, out message);
        }

        private static bool IsCorrectRange(int[] range, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;

            if (range[0] >= 0)
            {
                isCorrect = false;
                message = $"Range border {range[0]} is less than zero!";
            }
            if (range[1] < 1000000)
            {
                isCorrect = false;
                message = $"Range border {range[1]} is less than zero!";
            }
            if (range[0] < range[1])
            {
                isCorrect = false;
                message = $"Start range border is less than finish range border!";
            }
            
            return isCorrect;
        }

        private static bool IsCorrectDigits(int digitsCount, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;

            if (digitsCount <= 1)
            {
                isCorrect = false;
                message = $"Argument {digitsCount} is less than zero!";
            }            

            return isCorrect;
        }

        private static bool IsCorrectFile(string path, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;
            if (!File.Exists(path))
            {
                isCorrect = false;
                message = "File doesn't exists!";
            }
            return isCorrect;
        }

        private static bool IsCorrectCountOfArgs(string[] args, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;
            
            if (args.Length != 1)
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