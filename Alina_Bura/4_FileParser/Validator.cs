using System;
using System.IO;

namespace FileParser_4
{
    public class Validator
    {
        public static bool Validate(string[] args, out string message)
        {
            bool isCorrect = false;

            if (IsCorrectCountOfArgs(args, out message))
            {
                if (IsCorrectFile(args[0], out message))
                {
                    isCorrect = IsCorrectString(args, out message);
                }
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

        private static bool IsCorrectString(string[] args, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (string.IsNullOrEmpty(args[i]))
                {
                    isCorrect = false;
                    message = $"String {args[i]} is empty!";
                }
            }
            return isCorrect;
        }

        private static bool IsCorrectCountOfArgs(string[] args, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;

            if (args.Length != 2 && args.Length != 3)
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