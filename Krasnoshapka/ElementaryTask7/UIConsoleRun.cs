using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTasks8
{
    class UIConsoleRun
    {
        private const int RIGHT_COUNT_ARGS = 0;

        public static void BuildUI(string[] args)
        {
            if (args.Length==RIGHT_COUNT_ARGS)
            {
                do
                {
                    int border;

                    if (Int32.TryParse(args[0], out border))
                    {
                        SquareSequence squareSequence
                      = SquareSequence.SquareInitialize(border);

                        Console.WriteLine("Square sequence");

                        foreach (int number in squareSequence.GetSequence())
                        {
                            Console.WriteLine(number);
                        }
                    }
                    else
                    {
                        throw new FormatException("Please enter numbers");
                    }
                } while (true);  
            }
            else
            {
                Instruction();
            }
        }


      

        private static void Instruction()
        {
            Console.WriteLine("Please 1 border for Square or 2 for Fibonacci");
        }



    }
}
