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

        private int _border1 = 0;
        private int _border2 = 0;
        private string _instruction = null;
        private IEnumerable<int> _collection = null;
        private Range range = null;
        private OrderSQRTWithBorders _order = null;
        private int _taskNumber = 0;
        private IExeptionForFirstDemo exeptions = null;

        #endregion

        #region Constructors

        private UI()
        {
            _taskNumber = (int)BaseUI.TaskNumber.Task7;
            _instruction = InstructionReader.GiveInstruction();
            exeptions = new ExceptionsForAllAplication(_taskNumber);
        }

        public UI(string[] args) : this()
        {
            bool validArgs = false;
            int[] curArgs = new int[(int)CountOfArgs.SeventhTask];

            validArgs = Validator.CheckCountAndTypeArgs(args, out _border1, out _border2);
            
            bool startProg = Validator.CheckArgs(args);

            while (validArgs == false && startProg == false)
            {
                Console.WriteLine(_instruction);
                string row = Console.ReadLine();
                validArgs = Parser.ParseIntoIntNumbers(row, _taskNumber, out _border1, out _border2);
            }

        }

        #endregion

        #region Methods
        public override string CalculateOK()
        {
            string _message;

            try
            {
                range = new Borders(_border1, _border2);
                _order = new OrderSQRTWithBorders();
                _collection = _order.FindArrayOrder(range);
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

            Console.WriteLine("The choosen diapazon squared from {0} to {1}", _border1, _border2);
            result = _order.GetOrderFromCollection(_collection);

            return result;
        }

        #endregion


    }

    static class CheckArgsForContinue
    {

    }
}
