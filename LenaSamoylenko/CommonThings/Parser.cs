using CommonThings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonThings
{
    public class Parser
    {
        #region Fields

        private static SortedDictionary<int, string> _patternForRegex = new SortedDictionary<int, string>
        {
            [7] = @"(\b(\d +\W ?)) | (\B(\d *)\b)| (\b(\d *)\B)| ((\B)(\d +)(\B))",
            [8] = @"(\b(\d+\s?))"
        };

        #endregion

        #region Methods

        public static bool ParseIntoIntNumbers(string row, int taskNumber, ref int[] borders)
        {
            bool result = false;
      
            try
            {
                string pattern = _patternForRegex[taskNumber];

                Regex regex = new Regex(pattern);
                MatchCollection collectionOfIntNumbers = regex.Matches(row);
                string[] collection = new string[collectionOfIntNumbers.Count];
                int i = 0;

                foreach (var item in collectionOfIntNumbers)
                {
                    collection[i] = item.ToString();
                    i++;
                }
                
                result = Validator.CheckCountAndTypeArgs(collection, ref borders);
            }

            catch (Exception exception)
            {
                //add into log file

            }

            return result;
        }

        public static string GetArgument(string message)
        {
            Console.WriteLine(message);
            string _argument = Console.ReadLine();

            return _argument;
        }

        #endregion


    }
}
