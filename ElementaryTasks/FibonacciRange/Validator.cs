using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciRange
{
    public static class Validator
    {
        #region Method

        public static (int, int) Validate(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentNullException("Please input number!");

            if (args.Length == 2)
            {
                if (int.TryParse(args[0], out int beginNumber) && int.TryParse(args[1], out int endNumber))
                {
                    if (beginNumber >= 0 && endNumber > 0 && beginNumber < endNumber)
                        return (beginNumber, endNumber);
                    else
                        throw new ArgumentException("Begin must be bigger than 0 and end must be bigger than 1!\nAnd begin must be less than end!");
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
