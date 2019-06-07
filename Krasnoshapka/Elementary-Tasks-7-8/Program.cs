using System;
using NLog;

namespace ElementaryTask7
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {             
                UIConsoleRun.BuildUI(args);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Error(ex + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Error(ex + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex?.Message);
                logger.Error(ex + ex.Message);
            }

            logger.Trace("Application completed well");
        }
    }
}
