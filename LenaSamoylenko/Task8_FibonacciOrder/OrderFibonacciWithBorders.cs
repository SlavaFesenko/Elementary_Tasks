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

    public class OrderFibonacciWithBorders : Order
    {

        #region Fields

        private static readonly double _sqrt = Math.Sqrt(5);
        private static readonly double _fi = (1 + _sqrt) / 2;

        #endregion

        #region Constructors

        public OrderFibonacciWithBorders(IServiceProvider provider, ILogger<Order> logger) : base(provider, logger)
        {

            SetTaskNumber((int)TaskNumber.Task8);
        }

        #endregion

        #region Methods

        public override IEnumerable<int> FindArrayOrder(Range range)
        {
            using (_provider as IDisposable)
            {
                List<int> collection = new List<int>();
                if (_logger!=null)
                {
                    _logger.LogDebug(String.Format("{0} was started", System.Reflection.MethodBase.GetCurrentMethod().Name));
                }

                try
                {
                    for (int delta = range.LowerBorder; delta <= range.UpperBorder; delta++)
                    {
                        int _nextNumber = 0;

                        _nextNumber = OrderFibonacciWithBorders.FindFibonacciNumber(delta);

                        collection.Add(_nextNumber);
                    }
                }
                catch (Exception exception)
                {
                    _exceptions.GetException(exception);
                }


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
