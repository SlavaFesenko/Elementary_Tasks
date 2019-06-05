using System;
using CommonThings;
using CommonThings.AbstractClasses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Task8_FibonacciOrder
{
    public class Borders : Range
    {
        #region Fields
        private static readonly double _sqrt = Math.Sqrt(5);
        private static readonly double _fi = (1 + _sqrt) / 2;
        private ILogger<Range> _logger = null;

        #endregion

        #region Constructors

        public Borders(ILogger<Range> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        public override (int, int) FindLowAndUpBorder(int border1, int border2)
        {
            int _b1 = 0;
            int _b2 = 0;
            (_b1, _b2)= base.FindLowAndUpBorder(border1, border2);

            return (GetLowerBorderWithConditionals(_b1), GetUpperBoarderConditionals(_b2));
        }

        public override int GetLowerBorderWithConditionals(double lowerRange)
        {
            int numberOf = 0;
            try
            {
                numberOf = GetNumberInOrder(lowerRange);
                if (GetBorder(numberOf) < Math.Floor(lowerRange))
                {
                    numberOf++;
                }
            }
            catch (Exception exception)
            {
                Exception expFinal = _exeptions.GetException(exception);
                _logger.LogError(expFinal, "Error in {0} method", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }


            return numberOf;
        }

        public override int GetUpperBoarderConditionals(double upperRange)
        {
            int result = 0;
            try
            {
                result = GetNumberInOrder(upperRange);

                if (GetBorder(result) > Math.Floor(upperRange) && result > LowerBorder + 1)
                {
                    result--;
                }
            }
            catch (Exception exception)
            {
                Exception expFinal = _exeptions.GetException(exception);
                _logger.LogError(expFinal, "Error in {0} method", System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                Exception expFinal = _exeptions.GetException(exception);
                _logger.LogError(expFinal, "Error in {0} method", System.Reflection.MethodBase.GetCurrentMethod().Name);
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
