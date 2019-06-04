
namespace CommonThings.AbstractClasses
{
    public abstract class Range
    {
        #region Fields

        private int lowerBorder;
        private int upperBorder;

        #endregion

        #region Properties

        public int LowerBorder { get => lowerBorder; protected set => lowerBorder = value; }
        public int UpperBorder { get => upperBorder; protected set => upperBorder = value; }

        #endregion

        #region Methods

        public abstract int GetLowerBorderWithConditionals(double lowerInSecondPow);
        public abstract int GetUpperBoarderConditionals(double upperInSecondPow);

        public virtual void FindLowAndUpBorder(double border1, double border2)
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
        #endregion
    }
}
