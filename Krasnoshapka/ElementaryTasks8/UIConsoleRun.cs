using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ElementaryTasks8
{
    class UIConsoleRun
    {
        private const int FIBONACCI = 2;

        public static void BuildUI(string[] args)
        {
            if (args.Length == FIBONACCI)
            {
                Fibonacci(args);
            }
            else
                Instruction();
        }

        #region OtherMethods

        private static void Fibonacci(string[] args)
        {
            int leftBorder = 0;
            int rightBorder = 0;

            if (Int32.TryParse(args[0], out leftBorder) && Int32.TryParse(args[1], out rightBorder))
            {
                FibonacciSequence fibonacciSequence
               = FibonacciSequence.FibonacciInitialize(leftBorder, rightBorder);

                string result = "Fibonacci sequence:";
                Console.WriteLine(result);

                foreach (int number in fibonacciSequence.GetSequence())
                {
                    Console.Write(number +", ");
                }
            }
            else
            {
                throw new FormatException("Please enter numbers");
            }

           
        }

      

        private static void Instruction()
        {
            Console.WriteLine("Please 1 border for Square or 2 for Fibonacci");
        }

        #endregion

    }
}
