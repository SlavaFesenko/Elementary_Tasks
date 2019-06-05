using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public abstract class Sequence
    {
        
        public virtual int LeftNumber { get; private set; }
        public int RightNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftNumber">lowest number</param>
        /// <param name="rightNumber">higher number</param>
        public Sequence(int leftNumber, int rightNumber)
        {
            this.LeftNumber = leftNumber;
            this.RightNumber = rightNumber;
        }

        public abstract IEnumerable<int> GetSequenceCollection();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sequenceCollection">IEnumerable<int> Collection</param>
        /// <returns>string wich have collection int numbers, divided by comma ", " </returns>
        public virtual StringBuilder GetStringSequence(IEnumerable<int> sequenceCollection)
        {
            StringBuilder result = new StringBuilder();
            bool firstNumber = true;

            foreach (var number in sequenceCollection)
            {
                if (firstNumber)
                {
                    result.Append(number);
                    firstNumber = false;
                }
                else
                {
                    result.Append(", ");
                    result.Append(number);
                }
            }

            return result;
        }

    }
}
