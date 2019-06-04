using CommonLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8FibonacciSequence
{
    public class FibonacciSequence : BaseSequence
    {
        #region Constructor

        public FibonacciSequence(int leftRange, int rightRange) : base(leftRange, rightRange)
        {

        }

        #endregion

        #region Method 

        public IEnumerable<int> GetFibonacciSequence()
        {
            for(int index = 0; index < RightRange; index++ )
            {
                int temp = Fibonacci(index);

                if(temp >= LeftRange && temp <= RightRange)
                {
                    yield return temp;
                }
                if (temp >= RightRange)
                {
                    break;
                }
                
            }
        }

        static public int Fibonacci(int index)
        {
            return (int)(Math.Pow(_phi, index) / _sqrt5 + 0.5);
        }


        #endregion

        #region Fields

        static readonly double _sqrt5 = Math.Sqrt(5.0);
        static readonly double _phi = (_sqrt5 + 1) / 2;

        #endregion
    }
}
