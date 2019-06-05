using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToStringConvertor
{
    public static class Validator
    {
        /// <summary>
        /// Validate our arguments and return number or exception
        /// </summary>
        /// <param name="args">Arguments from console</param>
        /// <returns>Validated number</returns>
        public static int Validate(string[] args)
        {
            int result = 0;

            if (args.Length != 0)
            {
                if (args.Length == 1)
                {
                    string userNumber = args[0];
                    if ((userNumber[0] == '0' && userNumber.Length != 1) || (userNumber[0] == '-' && userNumber[1] == '0' && userNumber.Length != 2))
                        throw new FormatException("Unseccessful format! (Number couldn't start with 0)");                        
                    else
                    {
                        if (int.TryParse(userNumber, out result))
                            Console.WriteLine("Your number was successfully validated!");
                        else
                            throw new FormatException("Unseccessful format! (May be more than 10 symbols)");
                    }
                        
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
