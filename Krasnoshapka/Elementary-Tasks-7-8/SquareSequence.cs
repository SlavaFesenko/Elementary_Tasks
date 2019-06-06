using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Elementary_Tasks_7_8
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

            while (naturalNumber * naturalNumber < RightBorder)// for
            {
                yield return naturalNumber;
                naturalNumber++;
            }
        }
    }
}
