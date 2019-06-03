using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_7_8
{
    class FibonacciSequence : Sequence
    {
        private FibonacciSequence(int leftBorder, int rightBorder) : base(leftBorder, rightBorder)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
        }

        public static FibonacciSequence FibonacciInitialize(int leftBorder, int rightBorder)
        {
            if (Validator.ValidFibonacci(leftBorder, rightBorder))
            {
                return new FibonacciSequence(leftBorder, rightBorder);
            }
            else
            {
                throw new ArgumentException("Try again");
            }
        }

        public override IEnumerable<int> GetSequence()
        {
            int x = 0;
            int y = 1;

            for (int i = 0; i <= RightBorder; i = x)
            {
                x = y;
                y += i;

                if (i >= LeftBorder)
                {
                    yield return i;
                }
            }
        }
    }
}
