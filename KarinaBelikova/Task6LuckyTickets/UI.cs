using System;
using System.IO;

namespace Task6LuckyTickets
{
    public class UI
    {
        public static string GetPath()
        {
            Console.WriteLine("Input path to file with instructions (Example: C:\\Users\\kiit1\\Desktop): ");
            string path = Console.ReadLine();

            if (!File.Exists(path)) 
            {
                ShowInctructions();
                GetPath();      // to while loop and bool flag
            }

            return path;
        }

        public static void ShowCountOfLuckyTickets(int sum, InputModel model)
        {
            Console.WriteLine($"In range {model.LowLimit}-{model.UpLimit} it will be {sum} lucky tickets");
        }

        private static void ShowInctructions()
        {
            Console.WriteLine("Your file isn't exists. ");
        }

        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        public static void InvalidFileInstruction()
        {
            Console.WriteLine("File has invalid instructions! ");
        }
    }
}
