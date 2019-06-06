using NLog;
using System;
using System.IO;

namespace Task6LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                InputModel model = new InputModel(args);
                Application.Run(model);
            }
            catch (IOException e)
            {
                logger.Error($"IOException {e.Message}");
                UI.ShowErrorMessage(e);
            }

        }
    }
}
