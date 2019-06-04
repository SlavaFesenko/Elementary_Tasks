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
        private ILogger<Borders> _logger = null;
        private IServiceProvider _provider = null;

        public readonly double _border1;
        public readonly double _border2;

        #endregion

        #region Constructors


        public Borders(ILogger<Borders> logger, IServiceProvider provider, double border1, double border2)
        {
            toRecorgnizeExceptionType = new ExceptionsForAllAplication((int)TaskNumber.Task8);

            _border1 = border1;
            _border2 = border2;
            _logger = logger;
            _provider = provider;

            FindLowAndUpBorder(border1, border2);
        }

        #endregion

        #region Methods

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

            var fbNum = _provider.GetRequiredService<OrderFibonacciWithBorders>();
            result=fbNum.FindFibonacciNumber(value);

            return result;
        }

        #endregion

    }
}
