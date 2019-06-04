using System;
using System.Collections.Generic;
using System.Text;
using CommonThings;
using CommonThings.AbstractClasses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;

namespace Task8_FibonacciOrder
{

    class UI : BaseUI
    {
        #region Fields

        private int _border1 = 0;
        private int _border2 = 0;
        private string _instruction = null;
        private int _taskNumber = 0;

        private IEnumerable<int> _collection = null;
        private Range _range = null;
        private OrderFibonacciWithBorders _order = null;
        private Logger _logger = null;
        private IServiceProvider _provider = null;
        private IExeptionForFirstDemo exeptions = null;


        #endregion

        #region Constructors

        private UI()
        {
            Console.WriteLine("{0} Hello in Task8 {0}", new string('*', 10));

            _logger = LogManager.GetCurrentClassLogger();
            _taskNumber = (int)BaseUI.TaskNumber.Task8;
            _instruction = InstructionReader.GiveInstruction();
            exeptions = new ExceptionsForAllAplication(_taskNumber);
        }

        public UI(string[] args) : this()
        {
            //bool result = Validator.CheckCountAndTypeArgs(args, out message, out _border1, out _border2);

            bool validArgs = false;
            int[] curArgs = new int[(int)CountOfArgs.EightTask];

            validArgs = Validator.CheckCountAndTypeArgs(args, out _border1, out _border2);
            _instruction = InstructionReader.GiveInstruction();

            bool startProg = Validator.CheckArgs(args);

            while (validArgs == false && startProg == false)
            {
                Console.WriteLine();
                Console.WriteLine(_instruction);
                string row = Console.ReadLine();
                validArgs = Parser.ParseIntoIntNumbers(row, _taskNumber, out _border1, out _border2);
            }

        }

        #endregion

        #region Methods

        public override string CalculateOK()
        {
            string _message = null;
            //_logger.LogDebug()

            try
            {
                using (_provider as IDisposable)
                {
                    _provider = CommonThings.Logger<Borders>.HelperForLogging();
                    _range = _provider.GetRequiredService<Borders>();//new Borders();
                    _range.SetValue(_border1, _border2, exeptions);
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
                Exception exceptionFinal = exeptions.GetException(exception);

                _message = "Some problems\n";
                _logger.Error(exceptionFinal, "Stopped program because of exception");
            }

            return _message;
        }

        public override string PrintIntoConsole()
        {
            string result = null;

            Console.WriteLine("The choosen diapazon from {0} to {1} is:", _border1, _border2);
            result = _order.GetOrderFromCollection(_collection);

            return result;
        }

        #endregion

    }
}

