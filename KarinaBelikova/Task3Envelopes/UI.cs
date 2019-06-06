using System;
using NLog;

namespace Task2Envelopes
{
    public static class UI
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public static double[] InputEnvelopesData()
        {
            double[] parametors = new double[Constants.COUNT_OF_SIDES];
            Display("Input 4 numbers (width and height for two envelopes): ");         
            
            for (int i = 0; i < parametors.Length; i++)
            {
                if(!double.TryParse(Console.ReadLine(), out parametors[i]) ||
                    !Validator.IsCorrectEnvelopeSide(parametors[i]))
                {
                    _log.Info($"Input isn't correct");
                    IncorrectInput();                   
                    i--;
                }
            }

            _log.Info("Input is correct");

            return parametors;
        }

        public static void Display(string message)
        {
            Console.WriteLine($"{message}");
        }

        public static void IncorrectInput()
        {
            _log.Info("Incorrect input");
            Display("Envelope side must be a number, above zero. Try again: ");            
        }

        public static void ShowErrorMessage(Exception e)
        {
            _log.Info(e.Message);
            Display(e.Message);
            Console.ReadLine();
        }

    }
}
