using System;
using NLog;

namespace Task2Envelopes
{
    class Program
    {        
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                do
                {
                    Application.Run();
                }
                while (!Application.Exit());               
            }
            catch (FormatException e)
            {
                logger.Error($"Format Exception: {e.Message}");
                UI.ShowErrorMessage(e);
            }           
        }
    }
}
