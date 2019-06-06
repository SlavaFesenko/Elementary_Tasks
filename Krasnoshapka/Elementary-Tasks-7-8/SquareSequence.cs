using System.Collections.Generic;
using Shared;

namespace ElementaryTask7
{
   public class SquareSequence : Sequence
    {
        private SquareSequence(int leftBorder, int rightBorder) : base(leftBorder, rightBorder) { }

       
        public static SquareSequence SquareInitialize(int rightBorder)
        {
            SquareSequence sequence = null;

            if (Validator.ValidSquare(rightBorder))
            {
                sequence = new SquareSequence(1, rightBorder);
            }

            return sequence;
        }

        public override IEnumerable<int> GetSequence()
        {
            int naturalNumber = 1;

            while (naturalNumber * naturalNumber < RightBorder)
            {
                yield return naturalNumber;
                naturalNumber++;
            }
        }
    }
}
