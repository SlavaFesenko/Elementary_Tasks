using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_7_8
{
    class UIConsoleRun
    {
        private const int SQUARE = 1;
        private const int FIBONACCI = 2;

        public static void BuildUI(string[] args)
        {
            switch (args.Length)
            {
                case SQUARE:   
                    Square(args);
                    break;
                case FIBONACCI:
                    Fibonacci(args);
                    break;
                default:
                    Instruction();
                    break;
            }
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

                Console.WriteLine("Fibonacci sequence:");

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

        private static void Square(string[] args)
        {
            int border = Validator.Parsed(args[0]);

            if (Int32.TryParse(args[0], out border))
            {
                SquareSequence squareSequence
                = SquareSequence.SquareInitialize(border);

                Console.WriteLine("Square sequence:");

                foreach (int number in squareSequence.GetSequence())
                {
                    Console.Write(number+", ");
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
