using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalyzer
{
    class Program
    {
        static void Main()
        {
            Run();
            Console.ReadLine();

        }

        static void Run()
        {
            bool isEndSession = true;

            do
            {
                UI.ShowResult(AnalyzeEnvelopes());
                UI.ShowMessage("Вы хотите продолжить?");
                isEndSession = UI.AskUserAboutEndProgram();
            }
            while (!isEndSession);
        }


        private static string AnalyzeEnvelopes()
        {
            string result;
            Envelope firstEnvelope = new Envelope(UI.ReadFromConsoleNumber("первого", "первого"), UI.ReadFromConsoleNumber("первого", "второго"));
            Envelope secondEnvelope = new Envelope(UI.ReadFromConsoleNumber("второго", "первого"), UI.ReadFromConsoleNumber("второго", "второго"));

            if (firstEnvelope.IsCanPutInEnvelope(secondEnvelope))
            {
                result = "Мы можем вложить один конверт в другой";
            }
            else
            {
                result = "Мы не можем вложить один конверт в другой";
            }

            return result;
        }
    }
}
