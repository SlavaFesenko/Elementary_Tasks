using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalNumbersSequence
{
    public static class Validator
    {
        #region Method

        public static int Validate(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentNullException("Please input number!");

            if (args.Length == 1)
            {
                if (int.TryParse(args[0], out int number))
                {
                    if (number > 0)
                        return number;
                    else
                        throw new ArgumentException("Number must be greater than 0!");
                }
                else
                    throw new FormatException("Unsuccessful format!");
            }
            else
                throw new FormatException("Unsuccessful format!");
        }

        #endregion
    }
}
