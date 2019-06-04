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

        private double _border1 = 0;
        private double _border2 = 0;
        private IEnumerable<int> _collection = null;
        private Range _range = null;
        OrderFibonacciWithBorders _order = null;
        private Logger _logger = null;
        private IServiceProvider _servicesProvider = null;
        private IServiceProvider _providerBorder = null; 

        #endregion

        #region Constructors

        private UI()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _servicesProvider = CommonThings.Logger<UI>.HelperForLogging();
            _providerBorder = CommonThings.Logger<Borders>.HelperForLogging();

        }

        public UI(string[] args, out string message) : this()
        {
            message = Validator.CheckCountAndTypeArgs(args, out message, out _border1, out _border2);
        }

        #endregion

        #region Methods

        public override string CalculateOK()
        {
            string _message;
            //_logger.LogDebug()

            try
            {
                //add part with dispose
                _range = _providerBorder.GetRequiredService<Borders>();//new Borders();
                var _orderRunnet = _servicesProvider.GetRequiredService<OrderFibonacciWithBorders>();
                //_order = new OrderFibonacciWithBorders(_servicesProvider, _logger);
                _collection = _order.FindArrayOrder(_range);
                _message = "Congratulations, the calculation was finished";
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

