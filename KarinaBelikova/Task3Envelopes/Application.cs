using System;

namespace Task2Envelopes
{
    public class Application
    {
        public static void Run()
        {
            double[] envelopesSides = UI.InputEnvelopesData();

            Envelope firstEnvelope = new Envelope(envelopesSides[0], envelopesSides[1]);
            Envelope secondEnvelope = new Envelope(envelopesSides[2], envelopesSides[3]);

            UI.Display(ResultOfComparison(firstEnvelope, secondEnvelope));

            Console.ReadKey();
        }

        private static string ResultOfComparison(Envelope firstEnvelope, Envelope secondEnvelope)
        {
            string result = "";

            if (firstEnvelope.CompareTo(secondEnvelope) == 1)
            {
                result = "Second envelope can be put in first envelope";                
            }
            else if (secondEnvelope.CompareTo(firstEnvelope) == 1)
            {
                result = "First envelope can be put in second envelope. ";
            }
            else
            {
                result = "Envelopes cannot be nested in other";
            }

            return result;
        }

        public static bool Exit()
        {
            UI.Display("Do you want to exit? Press 'Esc' ");

            return (Console.ReadKey(true).Key == ConsoleKey.Escape);
        }
    }
}
