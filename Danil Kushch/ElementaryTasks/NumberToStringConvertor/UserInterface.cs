using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToStringConvertor
{
    public static class UserInterface
    {
        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        public static void Display(int number)
        {
            Console.WriteLine($"Your number {number} was converted to string:");
            Console.WriteLine($"{Converter.Convert(number)}");
            Console.ReadLine();
        }
    }
}
