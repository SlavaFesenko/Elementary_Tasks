using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chess
{
    public static class Validator
    {
        private const int MAX_VALUE = 30;

        public static (int, int) Validate(string[] args)
        {
            int rows = 0;
            int columns = 0;

            if (args.Length == 0)
                throw new ArgumentNullException("Please input rows and colomns!");
            if (args.Length != 2)
                throw new FormatException("Unsuccessful format. You must write only two arguments!");
            else
            {
                if (int.TryParse(args[0], out rows) && int.TryParse(args[1], out columns))
                {
                    if (rows > 0 && columns > 0 && rows <= MAX_VALUE && columns <= MAX_VALUE)
                    {
                        Console.WriteLine($"Rows({rows}) and Columns({columns}) parametrs was successfully validated!\n");
                        return (rows, columns);
                    }
                    else
                        throw new ArgumentException($"Rows({rows}) or Colomns({columns}) parametr out of range\n(Must be bigger than 0 and less than {MAX_VALUE})");
                }
                else
                    throw new FormatException("Can't parse rows or colomns");
            }
        }
    }
}
