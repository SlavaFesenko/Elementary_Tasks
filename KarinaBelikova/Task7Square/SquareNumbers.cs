using System.Collections;
using System.Collections.Generic;

namespace Task7Square // _ - нельзя
{
    public class SquareNumbers : Sequence //TODO : IEnumerable // GetEnumerator
    {      
        #region Constructor

        public SquareNumbers(int upLimit) : base(1, upLimit) { }

        #endregion

        public override IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }


        #region Iterator

        public IEnumerable<int> GetSequence()   //TODO Method if(GetNextNumber)  
        {
            for (int i = 0; i < _upLimit; i++)
            {
                if (i * i < _upLimit)
                {
                    yield return i;
                }
            }
        }    
        
        #endregion  
    }
}
