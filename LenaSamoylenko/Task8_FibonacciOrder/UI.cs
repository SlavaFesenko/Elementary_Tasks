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
        private IEnumerable<int> _collection = null;
        private Range _range = null;
        OrderFibonacciWithBorders _order = null;
        private Logger _logger = null;
        //private IServiceProvider _servicesProvider = null;
        private IServiceProvider _provider = null;
        private string _instruction = null;

        #endregion

        #region Constructors

        private UI()
        {
            Console.WriteLine("{0} Hello in Task8 {0}", new string('*', 10));

            _logger = LogManager.GetCurrentClassLogger();
            //_servicesProvider = CommonThings.Logger<UI>.HelperForLogging();
           
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
                Console.WriteLine(_instruction);
                string row = Console.ReadLine();
                validArgs = Parser.ParseIntoIntNumbers(row, out _border1, out _border2);
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
                    _range.SetValue(_border1, _border2);
                }

                using (_provider as IDisposable)
                {
                    _provider = CommonThings.Logger<OrderFibonacciWithBorders>.HelperForLogging();
                    _order = _provider.GetRequiredService<OrderFibonacciWithBorders>();
                    _collection = _order.FindArrayOrder(_range);
                }

                //_order = new OrderFibonacciWithBorders(_servicesProvider, _logger);

                _message = "Congratulations, the calculation was finished";
            }
            catch (System.InvalidOperationException exception)
            {
                _logger.Error(exception, "Stopped program because of exception");
            }
            catch (Exception exception)
            {
                //add to log file
                _message = "Some problems";
                _logger.Error(exception, "Stopped program because of exception");
            }

            return _message;
        }

        public override string PrintIntoConsole()
        {
            string result = null;

            Console.WriteLine("The choosen diapazon from {0} to {1}", _border1, _border2);
            result = _order.GetOrderFromCollection(_collection);

            return result;
        }

        #endregion

    }
}

