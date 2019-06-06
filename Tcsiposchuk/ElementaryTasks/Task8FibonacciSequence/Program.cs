using System;

namespace Task8FibonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = GetReadyArgument(args);
            FibonacciSequence fibSequence = new FibonacciSequence(range[0], range[1]);
            UI.PrintResult(range, fibSequence.GetFibonacciSequence());

            Console.ReadLine();
        }

        private static int [] GetReadyArgument(string[] args)
        {
            int[] readyArgs;

            if (!Validator.CheckArgument(args,out readyArgs))
            {
                UI.ShowInstruction();
                readyArgs = new int[2];
                readyArgs[0] = UI.GetNaturalNumberFromConsole();
                readyArgs[1] = UI.GetNaturalNumberFromConsole(readyArgs[0]);
            }

            return readyArgs;
        }

    }
}
