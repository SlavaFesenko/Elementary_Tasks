using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_8Sequences
{
    public abstract class Sequence : IEnumerable
    {
        #region Fields

        protected int _lowLimit = 0;
        protected int _upLimit = 0;

        #endregion

        #region Constructor

        public Sequence(int lowLimit, int upLimit)
        {
            _lowLimit = lowLimit;
            _upLimit = upLimit;
        }

        #endregion

        public abstract IEnumerator GetEnumerator();
    }
}
