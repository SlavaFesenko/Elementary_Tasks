using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;


namespace ElementaryTasks8
{
   public class FibonacciSequence : Sequence
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
                throw new ArgumentException("Nambers must be natural and Left number must be smaller than right");
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
