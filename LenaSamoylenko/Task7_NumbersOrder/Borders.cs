using System;
using System.Collections.Generic;
using System.Text;
using CommonThings.AbstractClasses;

namespace Task7_NumbersOrder
{
    class Borders : Range
    {
        #region Constructors

        public Borders(int border1, int border2)
        {
            FindLowAndUpBorder(border1, border2);
        }

        #endregion

        #region Methods

        public override int GetLowerBorderWithConditionals(double lowerInSecondPow)
        {
            int lowBorder = 0;

            double sqrtFromLowerBorder = Math.Sqrt(lowerInSecondPow);
            lowBorder = (int)Math.Floor(sqrtFromLowerBorder);

            return lowBorder;
        }

        public override int GetUpperBoarderConditionals(double upperInSecondPow)
        {
            int upBorder = 0;

            double sqrtFromLowerBorder = Math.Sqrt(upperInSecondPow);
            upBorder = (int)Math.Ceiling(sqrtFromLowerBorder);

            return upBorder;
        }

        #endregion

    }
}


