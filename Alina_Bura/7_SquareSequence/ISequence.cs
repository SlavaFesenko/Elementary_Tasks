using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSequence_7
{
    public interface ISequence
    {
        int StartNumber { get; }
        int FinishNumber { get; }

        IEnumerable<int> GetSequence();
    }
}
