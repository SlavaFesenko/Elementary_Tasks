using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace TextParser
{
    public static class Validator
    {
        public static Mode Validate(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentNullException("Please input arguments!");

            if (Regex.IsMatch(args[0], @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$"))
                throw new IOException("Uncorrect path!");

            if (args.Length == 2)
            {
                Console.WriteLine("You choose find and count mode!");
                return Mode.FindAndCount;
            }
            else if (args.Length == 3)
            {
                Console.WriteLine("You choose find and replace mode!");
                return Mode.FindAndReplace;
            }
            else
                throw new FormatException("Unseccessful format! Use format:\n1. <path> <string to count>\n2. < path> <string to search> <string to replace>");

        }
    }
}
