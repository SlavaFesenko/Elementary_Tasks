using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] readyArgs = GetReadyArgs(args);
            Board board = new Board(readyArgs[0], readyArgs[1]);
            UI.PrintBoard(board);

            Console.ReadLine();
        }

        private static int[] GetReadyArgs(string[] args)
        {
            int[] readyArgs;
            if (Validator.IsLenghtArgsInvalid(args))
            {
                UI.ShowInstruction();
                readyArgs = GetArgsFromUI();
            }
            else
            {
                if (Validator.IsValidArgs(args, out int firstArgument, out int secondArgument))
                {
                    readyArgs = new int[] { firstArgument, secondArgument };
                }
                else
                {
                    UI.ShowError("Было указано неподходящее значение, попробуйте еще раз \n");
                    readyArgs = GetArgsFromUI();
                }
            }

            return readyArgs;
        }

        private static int[] GetArgsFromUI()
        {
            int[] readyArgs = new int[2];

            UI.ShowMessage("Нужно задать ширину.");
            readyArgs[0] = UI.ReadParametr();
            UI.ShowMessage("Нужно задать высоту.");
            readyArgs[1] = UI.ReadParametr();
            
            return readyArgs;
        }
    }
}
