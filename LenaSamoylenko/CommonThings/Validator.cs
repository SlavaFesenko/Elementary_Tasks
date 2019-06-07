using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CommonThings
{
}

namespace CommonThings
{
    public static class Validator
    {
        #region Task7

        public static bool CheckArgs(string[] args, int countOfArgs)
        {
            bool couldContinue = false;

            if (args.Length == countOfArgs)
            {
                couldContinue = true;
            }
            return couldContinue;
        }

        public static bool CheckCountAndTypeArgs(string[] args, ref int[] borders)
        {
            bool result = false;

            for (int number = 0; number < args.Length; number++)
            {
                bool afterParsing = Int32.TryParse(args[number], out borders[number]);

                if (afterParsing)
                {
                    if (borders[number] >=  0)
                    {
                        result = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result;
        }
        #endregion
        public static bool IsNumberCorrect(string number, out double border)
        {
            bool result;

            result = Double.TryParse(number, out border);

            if (border < 0)
            {
                result = false;
            }

            return result;
        }

        public static bool VarTypeCheck(string parameter1, string parameter2, string parameter3, out double[] numbers)
        {
            bool result = false;
            numbers = new double[3];

            bool resultForVar1 = Double.TryParse(parameter1, out numbers[0]);
            bool resultForVar2 = Double.TryParse(parameter2, out numbers[1]);
            bool resultForVar3 = Double.TryParse(parameter3, out numbers[2]);

            if (resultForVar1 == true && resultForVar2 == true && resultForVar3 == true)
            {
                result = true;
            }

            return result;
        }

        public static bool VarTypeCheck(string parameter1, string parameter2, out int number1, out int number2)
        {
            bool result = false;

            bool resultForVar1 = Int32.TryParse(parameter1, out number1);
            bool resultForVar2 = Int32.TryParse(parameter2, out number2);

            if (resultForVar1 == true && resultForVar2 == true)
            {
                result = true;
            }

            return result;
        }

        public static bool ParameterIsPositive(int parameter1)
        {
            bool result = false;

            result = parameter1.Equals(Math.Abs(parameter1));

            return result;
        }

        public static bool RowParsing(string row, int parameterCount, out List<string> AllValue)
        {
            bool result = false;
            AllValue = new List<string>();
            AllValue.Clear();

            Regex conditional = new Regex(@"(\d+W?)|([a-z]+\w?)", RegexOptions.IgnoreCase);
            MatchCollection matches = conditional.Matches(row);

            if (parameterCount * 2 - 1 == matches.Count)
            {
                result = true;
                foreach (var value in matches)
                {
                    AllValue.Add(value.ToString());
                }
            }

            return result;
        }

        public static string ChangeRegistrToLowwer(string row)
        {
            string result = null;

            result = row.ToLower();

            return result;
        }

        #region Task4

        public static bool IsFileExist(string path)
        {
            bool result;

            result = File.Exists(path);

            return result;
        }

        #endregion

    }
}
