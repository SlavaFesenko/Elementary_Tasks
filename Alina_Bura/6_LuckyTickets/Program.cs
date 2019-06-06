using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool isCorrect = GetParameters(args, out int digitsCount, out int[] range);
                if (isCorrect)
                {
                    TicketsMode mode = GetMode(args[0]);
                    Counter counter = CounterFactory.GetCounter(mode);
                    int count = counter.GetCount(digitsCount, range[0], range[1]);

                    UI.PrintCount(count);
                }
            }
            catch (InvalidCastException ex)
            {
                UI.PrintErrorMessage(ex.Message);
            }
            catch (CaseNotFoundException ex)
            {
                UI.PrintErrorMessage(ex.Message);
            }

            Console.ReadLine();
        }

        private static bool GetParameters(string[] args, out int digitsCount, out int[] range)
        {
            digitsCount = UI.GetDigits();
            range = UI.GetRange();

            bool isCorrect = Validator.Validate(args, digitsCount, range, out string message);
            if (!isCorrect)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    UI.PrintErrorMessage(message);
                }
                UI.ShowInstruction();
            }

            return isCorrect;
        }

        private static TicketsMode GetMode(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                if (!Enum.TryParse(sr.ReadLine(), out TicketsMode mode))
                {
                    throw new InvalidCastException("Wrong string");
                }
                return mode;
            }
        }

       
    }
}
