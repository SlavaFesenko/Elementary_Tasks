using System;
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
