using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Numbers
{
    public class Validator
    {
        public static bool IsCorrect(string[] args)
        {
            bool IsCorrect = false;

            if (Validator.HasOneArguments(args) && Validator.IsValidNumber(args))
            {
                IsCorrect = true;
            }

            return IsCorrect;
        }

        private static bool HasOneArguments(string[] args)
        {
            bool IsCorrect = false;

            if (args.Length == 1)
            {
                IsCorrect = true;
            }

            return IsCorrect;
        }

        private static bool IsValidNumber(string[] args)
        {
            bool IsCorrect = false;

            if (int.TryParse(args[0], out int number))
            {
                IsCorrect = true;
            }

            return IsCorrect;
        }
    }
}
