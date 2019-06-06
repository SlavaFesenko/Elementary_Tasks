using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ElementaryTask7
{
    class UIConsoleRun
    {
        private const int SQUARE = 1;    
        static Logger logger = LogManager.GetCurrentClassLogger();


        public static void BuildUI(string[] args)
        {
            if (args.Length== SQUARE)
            {
                Square(args);
            }
            else
                Instruction();
        }

        #region OtherMethods
     

        private static void Square(string[] args)
        {
            int border=0;

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
            Console.WriteLine("Please enter only one number, like border of your seqence");
        }

        #endregion

    }
}
