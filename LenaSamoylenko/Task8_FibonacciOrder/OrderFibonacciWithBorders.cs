using System;
using System.Collections.Generic;
using CommonThings;
using CommonThings.AbstractClasses;
using CommonThings.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;

namespace Task8_FibonacciOrder
{
    
    enum EventIdForLogger { UseVoid = 10, UseProperty = 20, UseConstructor = 30 }

    class OrderFibonacciWithBorders : Order
    {

        #region Fields

        private static readonly double _sqrt = Math.Sqrt(5);
        private static readonly double _fi = (1 + _sqrt) / 2;
        private IExeptionForFirstDemo toRecorgnizeExceptionType;
        private readonly ILogger<OrderFibonacciWithBorders> _logger;
        private IServiceProvider _provider = null;
        #endregion

        #region Constructors

        public OrderFibonacciWithBorders(IServiceProvider provider, ILogger<OrderFibonacciWithBorders> logger)
        {
            _provider = provider;
            _logger = logger;

            SetTaskNumber((int)TaskNumber.Task8);
            toRecorgnizeExceptionType = new ExceptionsForAllAplication((int)TaskNumber.Task8);
        }

        #endregion

        #region Methods

        public override IEnumerable<int> FindArrayOrder(Range range)
        {
            using (_provider as IDisposable)
            {
                List<int> collection = new List<int>();
                var fibonacciOrder = _provider.GetRequiredService<OrderFibonacciWithBorders>();

                for (int delta = range.LowerBorder; delta <= range.UpperBorder; delta++)
                {
                    int _nextNumber = 0;

                    _nextNumber = OrderFibonacciWithBorders.FindFibonacciNumber(delta);
                    _logger.LogInformation(10, "Method {0} was called for count {1} number ib order", System.Reflection.MethodBase.GetCurrentMethod().Name, delta);

                    collection.Add(_nextNumber);
                }

                _logger.LogInformation(10, "Method {0} was called", System.Reflection.MethodBase.GetCurrentMethod().Name);

                return collection;
            }
        }

        internal static int FindFibonacciNumber(int serialNumber)
        {
            int result = 0;
            double helper = (Math.Pow(_fi, serialNumber) / _sqrt) + 0.5;

            result = (int)Math.Floor(helper);

            return result;
        }

        #endregion

    }
}
