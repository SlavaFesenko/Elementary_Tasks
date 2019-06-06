using System;

namespace LuckyTickets_6
{
    public class UI
    {
        public static void PrintErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowInstruction()
        {
            Console.WriteLine("Input name of text file, which has one of two strings: \"Moskov\" or \"Piter\"");
            Console.WriteLine("Input integer count of digits in ticket");

        }

        public static int[] GetRange()
        {
            int[] range = new int[2];

            Console.WriteLine("Input start range");
            range[0] = int.Parse(Console.ReadLine());

            Console.WriteLine("Input finish range");
            range[1] = int.Parse(Console.ReadLine());

            return range;
        }

        public static void PrintCount(int count)
        {
            Console.WriteLine(count);
        }

        public static int GetDigits()
        {
            Console.WriteLine("Input count of digits");
            return int.Parse(Console.ReadLine());
        }
    }
}