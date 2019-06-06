using CommonLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7Sequence
{
    public class NaturalNumberSequence : BaseSequence
    {
        #region Constructor

        public NaturalNumberSequence(int number) : base(1, number)
        {

        }

        #endregion

        #region Method 

        public IEnumerable<int> GetNaturalNumberSequence()
        {
            for(int index = LeftRange; RightRange > index*index; index++ )
            {
                yield return index;
            }
        }

        #endregion
    }
}
