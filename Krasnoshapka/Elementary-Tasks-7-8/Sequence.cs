using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_7_8
{
   public abstract class Sequence //TODO IEnumerable
    {

        public int LeftBorder { get; set; }
        public int RightBorder { get; set; }

        public Sequence(int leftBorder, int rightBorder)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
        }

        public abstract IEnumerable<int> GetSequence();
    }
}
