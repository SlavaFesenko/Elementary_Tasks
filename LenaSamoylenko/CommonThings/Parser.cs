using CommonThings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonThings
{
    public class Parser
    {
        public static bool ParseIntoIntNumbers(string row, out int border1, out int border2)
        {
            bool result = false;
            border1 = 0;
            border2 = 0;
     
            try
            {
                string pattern = @"(\b(\d+\W?))|(\B(\d*)\b)|(\b(\d*)\B)|((\B)(\d+)(\B))";

                Regex regex = new Regex(pattern);
                MatchCollection collectionOfIntNumbers = regex.Matches(row);
                string[] collection = new string[collectionOfIntNumbers.Count];
                int i = 0;

                foreach (var item in collectionOfIntNumbers)
                {
                    collection[i] = item.ToString();
                    i++;
                }


                result=Validator.CheckCountAndTypeArgs(collection, out border1, out border2);
                

            }

            catch (Exception exception)
            {
                //add into log file

            }

            return result;
        }
    }
}
