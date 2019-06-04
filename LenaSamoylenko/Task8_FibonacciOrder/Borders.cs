using System;
using CommonThings;
using CommonThings.AbstractClasses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Task8_FibonacciOrder
{
    class Borders : Range
    {
        #region Fields
        private static readonly double _sqrt = Math.Sqrt(5);
        private static readonly double _fi = (1 + _sqrt) / 2;
        private IExeptionForFirstDemo toRecorgnizeExceptionType;
        private IServiceProvider _provider = null;
        private ILogger<Range> _logger = null;

        public int _border1;
        public int _border2;

        #endregion

        #region Constructors

        public Borders(ILogger<Range> logger)
        {
            toRecorgnizeExceptionType = new ExceptionsForAllAplication((int)TaskNumber.Task8);
            _logger = logger;
        }

        #endregion

        #region Methods

        public override void FindLowAndUpBorder(int border1, int border2)
        {
            base.FindLowAndUpBorder(border1, border2);
        }

        public override int GetLowerBorderWithConditionals(double lowerRange)
        {
            int numberOf = 0;

            numberOf = GetNumberInOrder(lowerRange);
            if (GetBorder(numberOf) < Math.Floor(lowerRange))
            {
                numberOf++;
            }

            return numberOf;
        }

        public override int GetUpperBoarderConditionals(double upperRange)
        {
            int result = 0;

            result = GetNumberInOrder(upperRange);

            if (GetBorder(result) > Math.Floor(upperRange) && result > LowerBorder + 1)
            {
                result--;
            }

            return result;
        }

        private int GetNumberInOrder(double range)
        {
            int numberOf = 0;
            double toLog = 0;

            try
            {
                toLog = (Math.Abs(range - 0.5)) * _sqrt;
                numberOf = (int)Math.Round(Math.Log(toLog, _fi));
            }
            catch (Exception exception)
            {
                var exp = toRecorgnizeExceptionType.GetException(exception);
                _logger.LogError(exception, "Error in {0} method", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return numberOf;
        }

        private int GetBorder(int value)
        {
            int result = 0;

            result = OrderFibonacciWithBorders.FindFibonacciNumber(value);

            return result;
        }

        #endregion

    }
}
