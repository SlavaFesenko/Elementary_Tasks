using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Numbers
{
    public class LetterNumbersUI
    {
        public static void Print(int number)
        {
            string[] result = new string[10];

            WordsGenerator generator = new WordsGenerator(number);
            result = generator.GetWords();
            
            foreach (string word in result)
            {

                Console.WriteLine($"{word.ToString()} ");
            }
        }

        public static void ShowInstructions()
        {
            string instructions = "Your input data isn't correct.\nPlease input 1 argument (Example: 12)";
            Console.WriteLine(instructions);
        }
    }
}
