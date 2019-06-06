using System;

namespace Task8Fibonacci
{
    public class Validator
    {
        public static bool Validate(string[] args, out int lowlimit, out int uplimit)
        {
            if (args.Length == 0)
                throw new ArgumentNullException("Please input number!");

            if (args.Length == 2)
            {
                if (int.TryParse(args[0], out lowlimit) && int.TryParse(args[1], out uplimit))
                {
                    return (lowlimit >= 0 && uplimit > 0 && lowlimit < uplimit);                   
                }
                else
                    throw new FormatException("Unsuccessful format!");
            }
            else
                throw new FormatException("Unsuccessful format!");
        }
    }
}
