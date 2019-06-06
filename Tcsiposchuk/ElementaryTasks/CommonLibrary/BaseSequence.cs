using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public abstract class BaseSequence
    {
        #region Properties

        public virtual int LeftRange { get; protected set; }
        public virtual int RightRange { get; protected set; }

        #endregion

        #region Constructors

        public BaseSequence(int leftRange, int rightRange)
        {
            LeftRange = leftRange;
            RightRange = rightRange;
        }

        #endregion
    }
}
