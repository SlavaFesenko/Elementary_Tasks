using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence_8
{
    class Program
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            bool isCorrect = Validator.Validate(args, out int startRange, out int finishRange, out string message);
            if (!isCorrect)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    UI.PrintMessage(message);
                    log.Error(message);
                }
                UI.ShowInstruction();
            }

            ISequence sequence = new FibonacciSequence(startRange, finishRange);
            UI.PrintMessage(sequence.GetStringResult(sequence.GetSequence()));

            Console.ReadLine();
        }
    }
}
