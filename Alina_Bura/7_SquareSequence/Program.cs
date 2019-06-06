using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSequence_7
{
    class Program
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            try
            {
                int number = GetNumber(args);
                ISequence sequence = new SquareSequence(number);
                string result = SquareSequence.GetStringResult(sequence.GetSequence());
                UI.PrintMessage(result);
            }
            catch (ArgumentNullException ex)
            {
                UI.PrintMessage(ex.Message);
                log.Error(ex.Message);
            }
            catch (ArgumentException ex)
            {
                UI.PrintMessage(ex.Message);
                log.Error(ex.Message);
            }

            Console.ReadLine();
        }

        private static int GetNumber(string[] args)
        {
            bool isCorrect = Validator.Validate(args, out string message, out int number);
            if (!isCorrect)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    UI.PrintMessage(message);
                    log.Error(message);
                }
                UI.ShowInstruction();
            }

            return number;
        }
    }
}
