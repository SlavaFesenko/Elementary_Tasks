using System;
using System.IO;

namespace Task6LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"instructions.txt";
            string path = @"C:\Users\kiit1\Desktop\instructions.txt";

            try
            {
                InputModel model = new InputModel(path);
                Application.Run(model);
                Console.ReadKey();
            }
            catch (IOException e)
            {
                UI.ShowErrorMessage(e);
            }

        }
    }
}
