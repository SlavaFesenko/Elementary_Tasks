using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToStringConvertor
{
    public static class Validator
    {
        public static int Validate(string[] args)
        {
            int result = 0;

            if (args.Length != 0)
            {
                if (args.Length == 1)
                {
                    if (int.TryParse(args[0], out result))
                        Console.WriteLine("Your number was successful validated!");
                    else
                        throw new FormatException("Unseccessful format!");
                }
                else
                    throw new ArgumentException("Input only one number and try again!");
            }
            else
                throw new ArgumentNullException("Please insert number and try againg!");

            return result;
        }
    }
}
