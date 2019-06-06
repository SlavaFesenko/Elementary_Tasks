using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence_8
{
    interface ISequence
    {
        int StartRange { get; }
        int FinishRange { get; }

        IEnumerable<int> GetSequence();

        string GetStringResult(IEnumerable<int> sequence);
    }
}
