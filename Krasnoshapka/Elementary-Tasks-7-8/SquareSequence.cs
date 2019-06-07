using System.Collections.Generic;
using Shared;
using System;

namespace ElementaryTask7
{
   public class SquareSequence : Sequence
    {
        private SquareSequence(int leftBorder, int rightBorder) : base(leftBorder, rightBorder) { }

        /// <summary>
        /// Initializes a new sequence
        /// </summary>
        /// <param name="rightBorder">Number which the sequence seeks</param>
        /// <returns>Returns new sequence</returns>
        public static SquareSequence SquareInitialize(int rightBorder)
        {
            if (Validator.ValidSquare(rightBorder))
            {
                return new SquareSequence(1, rightBorder);
            }
            else
            {
                throw new ArgumentException("Incorrect parameters");
            }
         
        }

        /// <summary>
        ///  Method for getting elements by rule of less than square of number
        /// </summary>
        /// <returns>Returns element in sequence</returns>
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
