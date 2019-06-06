using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommonThings.AbstractClasses;
using Microsoft.Extensions.Logging;

namespace CommonThings.Interfaces
{
    public abstract class Order
    {
        #region Fields

        int _taskNumber=0;
        protected IExeptionForFirstDemo _exceptions = null;
        protected readonly ILogger<Order> _logger;
        protected IServiceProvider _provider = null;
        #endregion

        #region Indexer

        //public int this[int index]
        //{
        //    get { return _numbers[index]; }
        //}

        #endregion

        public Order(IServiceProvider provider, ILogger<Order> logger)
        {
            _provider = provider;
            _logger = logger;
            _exceptions = new ExceptionsForAllAplication((int)TaskNumber.Task8, logger);
        }

        #region Methods

        public abstract IEnumerable<int> FindArrayOrder(Range range);
    
        public string GetOrderFromCollection(IEnumerable<int> order)
        {
            StringBuilder orderInString;
            string result = null;
            int lenght = 0;

            try
            {
                orderInString = new StringBuilder();

                foreach (var number in order)
                {
                    orderInString.Append(number);
                    orderInString.Append(Path.PathSeparator);
                    orderInString.Append(" ");
                }

                lenght = orderInString.Length;
                result = orderInString.ToString(0, lenght - 2);
            }
            catch (Exception exception)
            {
                _exceptions.GetException(exception);
            }

            return result;
        }

        protected void SetTaskNumber(int taskNumber)
        {
            _taskNumber = taskNumber;
        }
        #endregion
    }
}
