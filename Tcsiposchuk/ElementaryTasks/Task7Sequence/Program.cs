using System;

namespace Task7Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = GetReadyArgument(args);
            NaturalNumberSequence naturalNumberSequence = new NaturalNumberSequence(range);
            UI.PrintResult(range, naturalNumberSequence.GetNaturalNumberSequence());

            Console.ReadLine();
        }

        private static int GetReadyArgument(string[] args)
        {
            int readyArgs;

            if (!Validator.CheckArgument(args,out readyArgs))
            {
                UI.ShowInstruction();
                readyArgs = UI.GetNaturalNumberFromConsole();
            }

            return readyArgs;
        }

    }
}
