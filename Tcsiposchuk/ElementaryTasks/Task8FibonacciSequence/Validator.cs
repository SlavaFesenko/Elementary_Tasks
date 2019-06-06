using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8FibonacciSequence
{
    public class Validator
    {
        public static bool IsValidNumber(string number, out int result)
        {
            return int.TryParse(number, out result) && result > 0;
        }

        public static bool CheckArgument(string [] args, out int[] resultRange)
        {
            bool result = false;
            resultRange = new int[2];

            if (args.Length == 2)
            {
                result = IsValidNumber(args[0], out resultRange[0]);
                result = IsValidNumber(args[1], out resultRange[1]);

            }

            return result;
        }
    }
}
