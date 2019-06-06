using NLog;
using System;

namespace Task6LuckyTickets
{
    public static class UI
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public static string GetPath()
        {
            Console.WriteLine("Input path to file with instructions (Example: instructions.txt): ");
            string path = Console.ReadLine();

            if (!Validator.IsPathValid(path)) 
            {
                ShowInctructions();
                GetPath();   
            }

            _log.Info($"Valid path {path}");
            return path;
        }

        public static void ShowCountOfLuckyTickets(int sum, InputModel model)
        {
            Console.WriteLine($"In range {model.LowLimit}-{model.UpLimit} it will be {sum} lucky tickets");
            _log.Info($"result: {sum}");
            Console.ReadKey();
        }

        public static void ShowInctructions()
        {
            _log.Info("Invalid path");
            Console.WriteLine("Your file isn't exists. ");
        }

        public static void ShowErrorMessage(Exception e)
        {
            _log.Info($"Exception {e.Message}");
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        public static void InvalidFileInstruction()
        {
            _log.Info("File has invalid instructions");
            Console.WriteLine("File has invalid instructions! ");
        }
    }
}
