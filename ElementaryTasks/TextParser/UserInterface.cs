using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public static class UserInterface
    {
        #region Methods

        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        public static void Display(IParserMode parser)
        {
            if (parser is PatternCounter)
                Console.WriteLine($"Count of same strings: {(parser as PatternCounter).Counter}");
            else if(parser is PatternReplacer)
            {
                Console.WriteLine("Your changed text:\n");
                foreach (string line in parser as PatternReplacer)
                {
                    Console.WriteLine(line);
                }
            }

            Console.ReadLine();
        }

        #endregion
    }
}
