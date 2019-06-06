using CommonThings;
using CommonThings.AbstractClasses;
using CommonThings.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;

namespace Task8_FibonacciOrder
{

    class UI : BaseUI
    {
        #region Fields

        private int[] _borders;
        private string _instruction = null;
        private int _taskNumber = 0;

        private IEnumerable<int> _collection = null;
        private Range _range = null;
        private Order _order = null;
        private Logger _logger = null;
        private IServiceProvider _provider = null;

        #endregion

        #region Constructors

        private UI()
        {
            string _instrLink = InstructionReader.GetFilePath();

            _logger = LogManager.GetCurrentClassLogger();
            _taskNumber = (int)TaskNumber.Task8;
            _instruction = InstructionReader.GiveInstruction(_instrLink, _logger);

            Console.WriteLine("{0} Hello in Task{1} {0}", new string('*', 10), _taskNumber);
        }

        public UI(string[] args) : this()
        {
            //bool result = Validator.CheckCountAndTypeArgs(args, out message, out _border1, out _border2);

            bool validArgs = false;
            bool startProg = false;
            _borders = new int[(int)CountOfArgs.EightTask];

            startProg = Validator.CheckArgs(args, (int)CommonThings.CountOfArgs.EightTask);

            if (startProg == true)
            {
                validArgs = Validator.CheckCountAndTypeArgs(args, ref _borders);
            }

            while (validArgs == false)
            {
                Console.WriteLine();
                Console.WriteLine(_instruction);
                string row = Console.ReadLine();
                validArgs = Parser.ParseIntoIntNumbers(row, _taskNumber, ref _borders);
            }
        }

        #endregion

        #region Methods

        public override string CalculateOK()
        {
            string _message = null;
            
            try
            {
                using (_provider as IDisposable)
                {
                    _provider = CommonThings.Logger<Borders>.HelperForLogging();

                    _range = _provider.GetRequiredService<Borders>();//new Borders();
                    (_range.LowerBorder, _range.UpperBorder) = _range.SetValue(_borders[0], _borders[1], _taskNumber);
                }

                using (_provider as IDisposable)
                {
                    _provider = CommonThings.Logger<OrderFibonacciWithBorders>.HelperForLogging();
                    _order = _provider.GetRequiredService<OrderFibonacciWithBorders>();
                    _collection = _order.FindArrayOrder(_range);
                }

                //_order = new OrderFibonacciWithBorders(_servicesProvider, _logger);

                _message = "Congratulations, the calculation was finished\n";
            }
            catch (Exception exception)
            {
                //add to log file
                _logger.Error(exception, "Stopped program because of exception");
                throw;
            }

            return _message;
        }

        public override string PrintIntoConsole()
        {
            string result = null;

            Console.WriteLine("The choosen diapazon from {0} to {1} is:", _borders[0], _borders[1]);
            result = _order.GetOrderFromCollection(_collection);

            return result;
        }

        #endregion

    }
}

