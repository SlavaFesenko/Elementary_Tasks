using System;
using System.Collections.Generic;
using System.Text;
using CommonThings;
using CommonThings.AbstractClasses;

namespace Task7_NumbersOrder
{
    public class UI : BaseUI
    {
        #region Fields

        int border1 = 0;
        int border2 = 0;
        IEnumerable<int> collection = null;
        Range range = null;
        OrderSQRTWithBorders order = null;
        private string _instruction = null;


        #endregion

        #region Constructors

        public UI(string[] args)
        {
            bool validArgs = false;
            int[] curArgs = new int[(int)CountOfArgs.SeventhTask];

            validArgs = Validator.CheckCountAndTypeArgs(args, out border1, out border2);
            _instruction = InstructionReader.GiveInstruction();

            bool startProg = CheckArgsForContinue.CheckArgs(args);

            while (validArgs == false && startProg == false)
            {
                Console.WriteLine(_instruction);
                string row = Console.ReadLine();
                validArgs = Parser.ParseIntoIntNumbers(row, out border1, out border2);
            }

        }

        #endregion

        #region Methods
        public override string CalculateOK()
        {
            string _message;

            try
            {
                range = new Borders(border1, border2);
                order = new OrderSQRTWithBorders();
                collection = order.FindArrayOrder(range);
                _message = "Congratulations, the calculation was finished";
            }
            catch (Exception exeption)
            {
                //add to log file
                _message = "Some problems";
            }

            return _message;
        }

        public override string PrintIntoConsole()
        {
            string result = null;

            Console.WriteLine("The choosen diapazon squared from {0} to {1}", border1, border2);
            result = order.GetOrderFromCollection(collection);

            return result;
        }

        #endregion


    }

    static class CheckArgsForContinue
    {
        public static bool CheckArgs(string[] args)
        {
            bool couldContinue = false;

            if (args.Length == (int)CommonThings.CountOfArgs.SeventhTask)
            {
                couldContinue = true;
            }
            return couldContinue;
        }
    }
}
