using NLog;
using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            logger.Debug("Start program");
            Controller application = new Controller();

            StartApplication(args, application);
            while (!application.IsSuccessful)
            {
                StartApplicationWithoutArgs(application);
            }
            logger.Debug("Successful finish program");

            Console.ReadLine();
        }

        private static void StartApplicationWithoutArgs(Controller application)
        {
            try
            {
                application.Run();
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.Message);
                UI.ShowError(ex.Message);
            }
        }

        private static void StartApplication(string[] args, Controller application)
        {
            try
            {
                application.Run(args);
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.Message);
                UI.ShowError(ex.Message);
            }
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
