using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("Enter number: ");
                int number = Int32.Parse(Console.ReadLine());

                LetterNumbersUI.Print(number);
            }
            else if (Validator.IsCorrect(args))
            {
                int number = int.Parse(args[0]);

                LetterNumbersUI.Print(number);
            }
            else
            {
                LetterNumbersUI.ShowInstructions();
            }

            Console.ReadKey();
        }
    }

}
