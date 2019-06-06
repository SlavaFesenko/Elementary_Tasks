using System;
using System.IO;

namespace FileParser_4
{
    internal class Validator
    {
        internal static bool Validate(string[] args, int mode, out string message)
        {
            bool isCorrect = false;

            if (IsCorrectCountOfArgs(args, mode, out message))
            {
                if (IsCorrectFile(args[0], out message))
                {
                    isCorrect = IsCorrectString(args[1], out message);
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

        private static bool IsCorrectString(string str, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;
            if (string.IsNullOrEmpty(str))
            {
                isCorrect = false;
                message = $"String {str} is empty!";
            }
            return isCorrect;
        }

        private static bool IsCorrectCountOfArgs(string[] args, int mode, out string message)
        {
            bool isCorrect = true;
            message = string.Empty;

            int argsCount = 0;
            switch (mode)
            {
                case 1:
                    argsCount = 2;
                    break;
                case 2:
                    argsCount = 3;
                    break;
                default:
                    break;
            }

            if (args.Length != argsCount)
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