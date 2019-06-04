
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

        public int LowerBorder { get => lowerBorder; protected set => lowerBorder = value; }
        public int UpperBorder { get => upperBorder; protected set => upperBorder = value; }

        #endregion

        #region Methods

        public abstract int GetLowerBorderWithConditionals(double lowerInSecondPow);
        public abstract int GetUpperBoarderConditionals(double upperInSecondPow);

        public virtual void FindLowAndUpBorder(int border1, int border2)
        {
            if (border1 > border2)
            {
                LowerBorder = GetLowerBorderWithConditionals(border2);
                UpperBorder = GetUpperBoarderConditionals(border1);
            }
            else if (border2 > border1)
            {
                LowerBorder = GetLowerBorderWithConditionals(border1);
                UpperBorder = GetUpperBoarderConditionals(border2);
            }
            else
            {
                LowerBorder = UpperBorder = GetLowerBorderWithConditionals(border1);
            }
        }

        public virtual void SetValue(int border1, int border2, IExeptionForFirstDemo exceptions)
        {
            _exeptions = exceptions;
            FindLowAndUpBorder(border1, border2);
        }
        #endregion
    }
}
