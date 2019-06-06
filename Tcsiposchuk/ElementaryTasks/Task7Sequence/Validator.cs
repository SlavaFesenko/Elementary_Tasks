using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7Sequence
{
    public class Validator
    {
        public static bool IsValidNumber(string number, out int result)
        {
            return int.TryParse(number, out result) && result > 0;
        }

        public static bool CheckArgument(string [] args, out int resultNumber)
        {
            bool result = false;
            resultNumber = -1;

            if (args.Length == 1)
            {
                result = IsValidNumber(args[0], out resultNumber);
            }

            return result;
        }
    }
}
