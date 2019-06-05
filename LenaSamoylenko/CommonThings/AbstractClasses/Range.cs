
using Microsoft.Extensions.Logging;
using System;

namespace CommonThings.AbstractClasses
{
    public abstract class Range
    {
        #region Fields

        private int lowerBorder;
        private int upperBorder;
        private ILogger<Range> _logger = null;
        protected IExeptionForFirstDemo _exeptions = null;

        #endregion

        #region Properties

        public int LowerBorder { get => lowerBorder; set => lowerBorder = value; }
        public int UpperBorder { get => upperBorder; set => upperBorder = value; }

        #endregion

        #region Methods

        public abstract int GetLowerBorderWithConditionals(double lowerInSecondPow);
        public abstract int GetUpperBoarderConditionals(double upperInSecondPow);

        public virtual (int, int) FindLowAndUpBorder(int border1, int border2)
        {
            (int, int) borders = (0, 0);

            if (border1 > border2)
            {
                borders = (border2, border1);
            }
            else if (border2 > border1)
            {
                borders = (border1, border2);
            }
            else
            {
                borders = (border1, border1);
            }

            return borders;
        }

        public virtual (int, int) SetValue(int border1, int border2, IExeptionForFirstDemo exceptions)
        {
            (int, int) borders = (0, 0);

            _exeptions = exceptions;
            borders=FindLowAndUpBorder(border1, border2);

            return borders;
        }
        #endregion
    }
}
