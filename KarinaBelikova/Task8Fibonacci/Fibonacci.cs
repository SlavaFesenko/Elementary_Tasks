using System.Collections.Generic;

namespace Task8Fibonacci
{
    public class Fibonacci
    {
        #region Fields

        private int _lowLimit = 0;
        private int _upLimit = 0;

        #endregion

        #region Constructor

        public Fibonacci(int lowLimit, int upLimit)
        {
            _lowLimit = lowLimit;
            _upLimit = upLimit;
        }

        #endregion

        #region Iterator

        public IEnumerable<int> GetSequence()
        {
            int previous = 0;
            int next = 1;
            while (previous + next <= _upLimit)
            {
                int sum = previous + next;
                previous = next;
                next = sum;
                if (next > _lowLimit)
                {
                    yield return next;
                }
            }
        }

        #endregion

    }
}
