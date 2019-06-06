using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTasks2
{
    class UIConsole
    {
        public static void BuildUI(string[] args)
        {
            bool Finish = true;

            do
            {
                Finish = false;

                float heightFirstEnvelope;
                float widthFirstEnvelope;
                float heightSecondEnvelope;
                float widthSecondEnvelope;

                bool success = true;

                Console.WriteLine("Input height of first envelope:");
                success &= float.TryParse(Console.ReadLine(), out heightFirstEnvelope);
                Console.WriteLine("Input width of first envelope:");
                success &= float.TryParse(Console.ReadLine(), out widthFirstEnvelope);

                Console.WriteLine("Input height of second envelope:");
                success &= float.TryParse(Console.ReadLine(), out heightSecondEnvelope);
                Console.WriteLine("Input width of second envelope:");
                success &= float.TryParse(Console.ReadLine(), out widthSecondEnvelope);

                if (success)
                {
                    Envelope firstEnvelope = Envelope.EnvelopeInitialize(heightFirstEnvelope, widthFirstEnvelope);
                    Envelope secondEnvelope = Envelope.EnvelopeInitialize(heightSecondEnvelope, widthSecondEnvelope);
                    ComparisonResults(firstEnvelope, secondEnvelope);
                }
                else
                    throw new FormatException("Please enter sides by numbers");

                Finish = Repeat();
            }
            while (Finish);
        }  
    

          private static void ComparisonResults(Envelope firstEnvelope, Envelope secondEnvelope)
          {
              if (firstEnvelope.CompareTo(secondEnvelope) == 1)
              {
                  Console.WriteLine("Second envelope can be in first!");
              }
              else if (secondEnvelope.CompareTo(firstEnvelope) == 1)
              {
                  Console.WriteLine("First envelope can be in second!");
              }
              else
              {
                  Console.WriteLine("Envelopes cannot be nested");
              }
          }

        private static bool Repeat()
        {
            Console.WriteLine("To repeat type y/Y or yes/YES:");
            string answer = Console.ReadLine().ToLower();
            return answer == "y" || answer == "yes";
        }
    }
}
