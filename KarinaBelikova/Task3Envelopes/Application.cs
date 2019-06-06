using System;
using NLog;

namespace Task2Envelopes
{
    public static class Application
    {
        public static Logger _log = LogManager.GetCurrentClassLogger();

        public static void Run()
        {
            double[] envelopesSides = UI.InputEnvelopesData();

            Envelope firstEnvelope = new Envelope(envelopesSides[0], envelopesSides[1]);
            Envelope secondEnvelope = new Envelope(envelopesSides[2], envelopesSides[3]);

            UI.Display(ResultOfComparison(firstEnvelope, secondEnvelope));
        }

        public static string ResultOfComparison(Envelope firstEnvelope, Envelope secondEnvelope)
        {
            string result = "";

            if (firstEnvelope.CompareTo(secondEnvelope) == 1)
            {
                result = Constants.SECOND_IN_FIRST;
            }
            else if (secondEnvelope.CompareTo(firstEnvelope) == 1)
            {
                result = Constants.FIRST_IN_SECOND;
            }
            else
            {
                result = Constants.NOT_NESTED;
            }

            _log.Info($"Result of comparison: {result}");

            return result;
        }

        public static bool Exit()
        {
            UI.Display("Do you want to exit? Press 'Esc' ");
          
            return (Console.ReadKey(true).Key == ConsoleKey.Escape);
        }
    }
}
